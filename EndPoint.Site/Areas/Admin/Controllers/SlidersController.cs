using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Application.Services.Common.Queries.GetSlider;
using WebSite.reza.Application.Services.HomePages.AddNewSlider;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly  IAddNewSliderService _addNewSliderService;
        private readonly  IGetSliderService _getSliderService;

        public SlidersController(IAddNewSliderService addNewSliderService, IGetSliderService getSliderService)
        {
            _addNewSliderService = addNewSliderService;
            _getSliderService = getSliderService;
        }

        public IActionResult Index()
        {
            return View(_getSliderService.Execute().Data);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(IFormFile file,string link)
        {
            _addNewSliderService.Execute(file,link);
            return View();
        }

    }
}
