using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.FacadPatterns;

namespace EndPoint.Site.ViewComponents
{
    public class Search:ViewComponent
    {
        private readonly IProductFacadForSite _productFacadForSite;

        public Search(IProductFacadForSite productFacadForSite)
        {
            _productFacadForSite = productFacadForSite;
        }

        public IViewComponentResult Invoke()
        {
            return View(viewName: "Search", _productFacadForSite.GetCategoryService.Execute().Data);
        }
    }
}
