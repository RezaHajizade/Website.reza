using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Application.Services.HomePages.Commands.AddHomePageImages;
using WebSite.reza.Domain.Entities.HomePages;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageImagesController : Controller
    {

        private readonly IAddHomePageImageService _addHomePageImageService;

        public HomePageImagesController(IAddHomePageImageService addHomePageImageService)
        {
            _addHomePageImageService = addHomePageImageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(IFormFile file,string link,ImageLocation imageLocation)
        {
            _addHomePageImageService.Execute(new requestAddHomePageImagesDto
            {
                file = file,
                ImageLocation=imageLocation,
                Link=link
            });

            return View();
        }
    }
}
