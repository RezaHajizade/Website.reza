using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;
using WebSite.reza.Domain.Entities.HomePages;

namespace WebSite.reza.Application.Services.HomePages.Queries.GetHomePageImages
{
    public interface IGetHomePageImageService
    {
        ResultDto<List<HomePageImageDto>> Execute();
    }

    public class GetHomePageImageService : IGetHomePageImageService
    {
        private readonly IDataBaseContext _context;

        public GetHomePageImageService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<HomePageImageDto>> Execute()
        {
            var images = _context.homePageImages.OrderByDescending(p => p.Id)
                .Select(p => new HomePageImageDto
                {
                    Id = p.Id,
                    ImageLocation = p.ImageLocation,
                    link = p.Link,
                    Src = p.Src
                }).ToList();

            return new ResultDto<List<HomePageImageDto>>()
            {
                Data = images,
                IsSuccess = true
            };
        }
    }

    public class HomePageImageDto
    {
        public long Id { get; set; }
        public string Src { get; set; }
        public string link { get; set; }
        public ImageLocation  ImageLocation { get; set; }

    }
}
