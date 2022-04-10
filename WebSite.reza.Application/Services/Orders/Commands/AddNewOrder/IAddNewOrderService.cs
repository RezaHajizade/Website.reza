using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;
using WebSite.reza.Domain.Entities.Orders;

namespace WebSite.reza.Application.Services.Orders.Commands.AddNewOrder
{
    public interface IAddNewOrderService
    {
        ResultDto Execute(RequestAddNewOrderServiceDto request);

    }
    public class AddNewOrderService : IAddNewOrderService
    {
        private readonly IDataBaseContext _context;

        public AddNewOrderService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestAddNewOrderServiceDto request)
        {
            var user = _context.User.Find(request.UserId);
            var requestPay = _context.requestPays.Find(request.RequestPayId);
            var cart = _context.Carts.Include(p => p.CartItems)
                .ThenInclude(p=>p.Product)
                .Where(p => p.Id == request.CartId).FirstOrDefault();

            requestPay.IsPay = true;
            requestPay.PayDate = DateTime.Now;
            requestPay.RefId = request.RefId;
            requestPay.Authority = request.Authority;
            cart.Finished = true;

            Order order = new Order()
            {
                Address = "",
                orderState = OrderState.Processing,
                RequestPay = requestPay,
                User=user,
            };
            _context.Orders.Add(order);

            //اضافه کردن محصولات

            List<OrderDetail> OrderDetails = new List<OrderDetail>(); 
            foreach(var item in cart.CartItems)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    Count = item.Count,
                    Order = order,
                    Price = item.Product.Price,
                    Product = item.Product,
                };
                OrderDetails.Add(orderDetail);

            }
            _context.OrderDetail.AddRange(OrderDetails);

            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "",
            };

        }
    }

    public class RequestAddNewOrderServiceDto
    {
        public long CartId { get; set; }
        public long RequestPayId { get; set; }
        public long UserId { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0; 
    }
}
