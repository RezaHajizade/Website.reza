using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;
using WebSite.reza.Domain.Entities.Orders;
using WebSite.reza.Domain.Entities.Products;

namespace WebSite.reza.Application.Services.Orders.Queries
{
    public interface IGetUserOrdersService
    {
        ResultDto<List<GetUserOrderDto>> Execute(long UserId);

    }

    public class GetUserOrdersService : IGetUserOrdersService
    {
        private readonly IDataBaseContext _context;

        public GetUserOrdersService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetUserOrderDto>> Execute(long UserId)
        {


            var orders = _context.Orders
                .Include(p => p.OrderDetails)
                .ThenInclude(p=>p.Product)
                .Where(p => p.UserId == UserId)
                .OrderByDescending(p => p.Id).ToList().Select(p=> new GetUserOrderDto
                {
                     OrderId=p.Id,
                     OrderState=p.orderState,
                     OrderDetails=p.OrderDetails.Select(o=>new OrderDetailsDto
                     {
                         Count=o.Count,
                         Price=o.Price,
                         ProductName=o.Product.Name,
                         OrderDetailId=o.OrderId,
                         ProductId=o.ProductId,
                     }).ToList(),
                }).ToList();




            return new ResultDto<List<GetUserOrderDto>>
            {
                Data = orders,
                IsSuccess = true
            };

        }
    }

    public class GetUserOrderDto
    {
        public long OrderId { get; set; }
        public OrderState OrderState { get; set; }
        public long RequestPayId { get; set; }
        public List<OrderDetailsDto> OrderDetails { get; set; }
    }

    public class OrderDetailsDto
    {
        public long OrderDetailId { get; set; }
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }

        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }

}
