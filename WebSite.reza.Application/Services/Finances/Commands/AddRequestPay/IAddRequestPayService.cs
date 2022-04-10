using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;
using WebSite.reza.Domain.Entities.Finances;

namespace WebSite.reza.Application.Services.Finances.Commands.AddRequestPay
{
    public interface IAddRequestPayService
    {
        ResultDto<ResultRequestPayDto> Execute(int Amount, long UserId);
    }
    public class AddRequestPayService : IAddRequestPayService
    {
        private readonly IDataBaseContext _context;
        public AddRequestPayService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRequestPayDto> Execute(int Amount, long UserId)
        {
            var user = _context.User.Find(UserId);
            RequestPay requestPay = new RequestPay()
            {
                Amount = Amount,
                Guid = Guid.NewGuid(),
                IsPay = false,
                User = user,

            };
            _context.requestPays.Add(requestPay);
            _context.SaveChanges();

            return new ResultDto<ResultRequestPayDto>()
            {
                Data = new ResultRequestPayDto
                {
                    Guid = requestPay.Guid,
                    Amount = requestPay.Amount,
                    Email = user.Email,
                    RequestPayId = requestPay.Id,
                },
                IsSuccess = true,
            };
        }
    }

    public class ResultRequestPayDto
    {
        public Guid Guid { get; set; }
        public int Amount { get; set; }
        public string Email { get; set; }
        public long RequestPayId { get; set; }
    }
}