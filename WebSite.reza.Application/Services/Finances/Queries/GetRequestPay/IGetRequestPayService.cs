using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;

namespace WebSite.reza.Application.Services.Finances.Queries.GetRequestPay
{
    public interface IGetRequestPayService
    {
        ResultDto<RequestPayDto> Execute(Guid guid);

    }
    public class GetRequestPayService : IGetRequestPayService
    {
        private readonly IDataBaseContext _context;
        public GetRequestPayService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<RequestPayDto> Execute(Guid guid)
        {
            var requestPay = _context.requestPays.Where(p => p.Guid == guid).FirstOrDefault();

            if (requestPay != null)
            {
                return new ResultDto<RequestPayDto>()
                {
                    Data = new RequestPayDto()
                    {
                        Amount = requestPay.Amount,
                        Id=requestPay.Id,
                    },
                };
            }
            else
            {
                throw new Exception("request pay not found");
            }
        }
    }


    public class RequestPayDto
    {
        public long Id { get; set; }
        public int Amount { get; set; }
    }
}
