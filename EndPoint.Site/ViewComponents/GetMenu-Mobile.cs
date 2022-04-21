using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.FacadPatterns;

namespace EndPoint.Site.ViewComponents
{
    public class GetMenu_Mobile:ViewComponent
    {
        private readonly IProductFacadForSite _productFacadForSite;

        public GetMenu_Mobile(IProductFacadForSite productFacadForSite)
        {
            _productFacadForSite = productFacadForSite;
        }

        public IViewComponentResult Invoke()
        {
            return View(viewName: "GetMenu_Mobile", _productFacadForSite.GetMenuItemService.Execute().Data);
        }
    }
}
