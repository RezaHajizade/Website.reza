using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebSite.reza.Domain.Entities.Users;

namespace EndPoint.Site.Controllers
{
    [Authorize]
    public class UserClaimController : Controller
    {

        private readonly UserManager<User> _userManager;

        public UserClaimController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string ClaimType,string ClaimValue)
        {
            var user = _userManager.GetUserAsync(User).Result;

            Claim newclaim = new Claim(ClaimType, ClaimValue, ClaimValueTypes.String);

            var Result =_userManager.AddClaimAsync(user, newclaim).Result;

            if(Result.Succeeded)
            {
                return RedirectToAction("index", "home");
            }
            else
            {
                foreach(var item in Result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View();
        }
    }
}
