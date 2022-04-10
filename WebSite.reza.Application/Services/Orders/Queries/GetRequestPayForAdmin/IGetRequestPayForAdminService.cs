using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;

namespace WebSite.reza.Application.Services.Orders.Queries.GetRequestPayForAdmin
{
    public interface IGetRequestPayForAdminService
    {
        ResultDto<List<RequestPayDto>> Execute();
    }

    public class GetRequestPayForAdminService : IGetRequestPayForAdminService
    {

        private readonly IDataBaseContext _context;

        public GetRequestPayForAdminService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<RequestPayDto>> Execute()
        {
            var requestPay = _context.requestPays
                .Include(p=>p.User)
                .ToList()
                 .Select(p => new RequestPayDto
                 {
                     Id=p.Id,
                     Guid=p.Guid,
                     PayDate=p.PayDate,
                     UserName=p.User.FullName,
                     Amount=p.Amount,
                     Authority=p.Authority,
                     IsPay=p.IsPay,
                     RefId=p.RefId,
                     UserId=p.UserId,                     
                 }).ToList();



            return new ResultDto<List<RequestPayDto>>
            {
                Data = requestPay,
                IsSuccess = true,

            };
        }
    }

    public class RequestPayDto
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string UserName { get; set; }
        public long UserId { get; set; }
        public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0;
    }
}
