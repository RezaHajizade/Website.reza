using Dto.Payment;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Application.Services.Carts;
using WebSite.reza.Application.Services.Finances.Commands.AddRequestPay;
using WebSite.reza.Application.Services.Finances.Queries.GetRequestPay;
using WebSite.reza.Application.Services.Orders.Commands.AddNewOrder;
using ZarinPal.Class;

namespace EndPoint.Site.Controllers
{
    [Authorize("Customer")]
    public class PayController : Controller
    {
        private readonly IAddRequestPayService _addRequestPayService;
        private readonly ICartService _cartService;
        private readonly CookiesManager _cookiesManager;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        private readonly IGetRequestPayService _getRequestPayService;
        private readonly IAddNewOrderService _addNewOrderService;
        public PayController(IAddRequestPayService addRequestPayService, ICartService cartService, CookiesManager cookiesManager, IGetRequestPayService getRequestPayService, IAddNewOrderService addNewOrderService)
        {
            _addRequestPayService = addRequestPayService;
            _cartService = cartService;
            _cookiesManager = cookiesManager;
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
            _getRequestPayService = getRequestPayService;
            _addNewOrderService = addNewOrderService;
        }

        public async  Task<IActionResult> Index()
        {
            long? UserId = ClaimUtility.GetUserId(User);
            var cart = _cartService.GetMyCart(_cookiesManager.GetBrowserId(HttpContext), UserId);


            if (cart.Data.SumAmounge > 0)
            {
                var requestPay = _addRequestPayService.Execute(cart.Data.SumAmounge, UserId.Value);

                //ارسال درگاه پرداخت

                var result = await _payment.Request(new DtoRequest()
                {
                    Mobile = "09121112222",
                    CallbackUrl = $"https://localhost:44384/Pay/verify?guid={requestPay.Data.Guid}",
                    Description = "پرداخت فاکتور شماره "+requestPay.Data.RequestPayId,
                    Email = requestPay.Data.Email,
                    Amount = requestPay.Data.Amount,
                    //شناسه درگاه پرداخت ما
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
                }, ZarinPal.Class.Payment.Mode.sandbox);
                return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");

            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }         
        }
        public async Task<IActionResult> verify(Guid guid,string authority,string status)
        {
            var requestPay = _getRequestPayService.Execute(guid);

            var verification = await _payment.Verification(new DtoVerification
            {
                Amount = requestPay.Data.Amount,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Authority = authority
            }, Payment.Mode.sandbox);

            long? userId = ClaimUtility.GetUserId(User);
            var cart = _cartService.GetMyCart(_cookiesManager.GetBrowserId(HttpContext), userId);

            if(verification.Status==100)
            {
                _addNewOrderService.Execute(new RequestAddNewOrderServiceDto
                {
                    CartId = cart.Data.CartId,
                    UserId = userId.Value,
                    RequestPayId=requestPay.Data.Id,
                });

                // redirect to orders
                return RedirectToAction("Index", "Orders");
            }
            else
            {

            }
            return View();
        }
    }
}
