using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;

namespace WebSite.reza.Application.Services.Common.Queries.GetSlider
{
    public interface IGetSliderService
    {
        ResultDto<List<SliderDto>> Execute();
    }


    public class GetSliderServvice: IGetSliderService
    {
        private readonly IDataBaseContext _context;

        public GetSliderServvice(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<SliderDto>> Execute()
        {
            var sliders = _context.Sliders.OrderByDescending(p => p.Id).ToList().Select(
               p => new SliderDto
               {
                   Link=p.Link,
                   Src=p.Src
               }).ToList();

            return new ResultDto<List<SliderDto>>()
            {
                Data = sliders,
                IsSuccess = true,
            };
        }
    }
    public class SliderDto
    {
        public string Src { get; set; }
        public string Link { get; set; }
    }
}
