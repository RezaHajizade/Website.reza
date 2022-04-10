﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;
using WebSite.reza.Domain.Entities.Orders;

namespace WebSite.reza.Application.Services.Orders.Queries.GetOrdersForAdmin
{
    public interface IGetOrdersForAdminService
    {
        ResultDto<List<OrderDto>> Execute(OrderState orderState);

    }

    public class GetOrdersForAdminService : IGetOrdersForAdminService
    {
        private readonly IDataBaseContext _context;

        public GetOrdersForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<OrderDto>> Execute(OrderState orderState)
        {
            var orders = _context.Orders
                .Include(p => p.OrderDetails)
                .Where(p => p.orderState == orderState)
                .OrderByDescending(p => p.Id)
                .ToList()
                .Select(p => new OrderDto
                {
                    OrderId = p.Id,
                    InsertTime = p.InsertTime,
                    orderState = p.orderState,
                    ProductCount = p.OrderDetails.Count(),
                    RequestId = p.RequestPayId,
                    UserId = p.UserId
                }).ToList();


            return new ResultDto<List<OrderDto>>
            {
                Data = orders,
                IsSuccess = true
            };

        }
    }

    public class OrderDto
    {
        public long OrderId { get; set; }
        public long UserId { get; set; }
        public OrderState orderState { get; set; }
        public DateTime InsertTime { get; set; }
        public long RequestId { get; set; }
        public int ProductCount { get; set; }
    }
}
