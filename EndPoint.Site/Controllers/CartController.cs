using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Application.Services.Carts;

namespace EndPoint.Site.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly CookiesManager cookiesManager;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
            cookiesManager = new CookiesManager();
        }

        public IActionResult Index()
        {
          var userId=  ClaimUtility.GetUserId(User);

           var resultGetList= _cartService.GetMyCart(cookiesManager.GetBrowserId(HttpContext), userId);
            return View(resultGetList.Data);
        }


        public IActionResult AddToCart(long ProductId)
        {           
            var resultAdd = _cartService.AddToCart(ProductId, cookiesManager.GetBrowserId(HttpContext));
            return RedirectToAction("Index");
        }

        public IActionResult Add(long CartItemId)
        {
            _cartService.Add(CartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult LowOff(long CartItemId)
        {
            _cartService.LowOff(CartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(long ProductId)
        {
            _cartService.RemoveFromCart(ProductId, cookiesManager.GetBrowserId(HttpContext));
            return RedirectToAction("Index");

        }

    }
}
