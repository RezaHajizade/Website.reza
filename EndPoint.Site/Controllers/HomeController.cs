using EndPoint.Site.Models;
using EndPoint.Site.Models.ViewModels.HomePages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.FacadPatterns;
using WebSite.reza.Application.Services.Common.Queries.GetSlider;
using WebSite.reza.Application.Services.HomePages.Queries.GetHomePageImages;
using WebSite.reza.Application.Services.Products.Queries.GetProductForSite;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetSliderService _getSliderService;
        private readonly IGetHomePageImageService _homePageImageService;
        private readonly IProductFacadForSite _productFacadForSite;
        public HomeController(ILogger<HomeController> logger, 
            IGetSliderService getSliderService, 
            IGetHomePageImageService homePageImageService,
            IProductFacadForSite productFacadForSite)
        {
            _logger = logger;
            _getSliderService = getSliderService;
            _homePageImageService = homePageImageService;
            _productFacadForSite = productFacadForSite;
        }

        public IActionResult Index()
        {
            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _getSliderService.Execute().Data,
                PageImages = _homePageImageService.Execute().Data,
                Camera = _productFacadForSite.GetProductForSiteService.Execute(Ordering.theNewest, null, 1, 5, 11).Data.Products,
            };

            return View(homePage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
