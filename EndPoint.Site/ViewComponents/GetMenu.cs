using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.FacadPatterns;
using WebSite.reza.Application.Services.Common.Queries.GetMenuItem;

namespace EndPoint.Site.ViewComponents
{
    public class GetMenu : ViewComponent
    {
        private readonly IProductFacadForSite _productFacadForSite;

        public GetMenu(IProductFacadForSite productFacadForSite)
        {
            _productFacadForSite = productFacadForSite;
        }

        public IViewComponentResult Invoke()
        {
            var menuItem = _productFacadForSite.GetMenuItemService.Execute();
            return View(viewName: "GetMenu", menuItem.Data);
        }
    }
}
