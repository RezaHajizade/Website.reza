using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Application.Services.Orders.Queries.GetRequestPayForAdmin;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RequestpayController : Controller
    {
        private readonly IGetRequestPayForAdminService _getRequestPayForAdminService;

        public RequestpayController(IGetRequestPayForAdminService getRequestPayForAdminService)
        {
            _getRequestPayForAdminService = getRequestPayForAdminService;
        }

        public IActionResult Index()
        {
            return View(_getRequestPayForAdminService.Execute().Data);
        }
    }
}
