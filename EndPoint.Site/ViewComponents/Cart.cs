using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Application.Services.Carts;

namespace EndPoint.Site.ViewComponents
{
    public class Cart : ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly CookiesManager _cookiesManager;

        public Cart(ICartService cartService, CookiesManager cookiesManager)
        {
            _cartService = cartService;
            _cookiesManager = cookiesManager;
        }

        public IViewComponentResult Invoke()
        {
            var userId = ClaimUtility.GetUserId(HttpContext.User);
            return View(viewName: "Cart", _cartService.GetMyCart(_cookiesManager.GetBrowserId(HttpContext), userId).Data);
        }
    }
}
