using EndPoint.Site.Models.ViewModels.Password;
using EndPoint.Site.Models.ViewModels.SMS;
using EndPoint.Site.Models.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebSite.reza.Application.Services.Email;
using WebSite.reza.Common.Dto;
using WebSite.reza.Domain.Entities.Users;

namespace EndPoint.Site.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly EmailServices _emailServices;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailServices = new EmailServices();
        }

        public IActionResult Index()
        {
            return View();
        }
    
        public IActionResult Register()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            User newuser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FullName = registerViewModel.FullName,
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email,
            };
           
            var Result = _userManager.CreateAsync(newuser, registerViewModel.Password).Result;
            if (Result.Succeeded)
            {
               var rst= _userManager.AddToRoleAsync(newuser, "customer");
                var token=_userManager.GenerateEmailConfirmationTokenAsync(newuser).Result;
                string callbackUrl = Url.Action("ConfirmEmail", "Account", new
                {
                    UserId = newuser.Id,
                    Token = token,

                }, protocol: Request.Scheme);

                string body = $"لطفا برای فعال حساب کاربری بر روی لینک زیر کلیک کنید!  <br/> <a href={callbackUrl}> Link </a>";
                _emailServices.Execute(newuser.Email,body,"فعال سازی حساب");

                return RedirectToAction("DisplayEmail");
            }


            string message = "";
            foreach (var item in Result.Errors.ToList())
            {
                message += item.Description + Environment.NewLine;
            }
            TempData["Message"] = message;
            return View(registerViewModel);
       
         }

        public IActionResult DisplayEmail()
        {
            return View();
        }

        public IActionResult ConfirmEmail(string UserId,string Token)
        {
            if(UserId==null ||Token==null)
            {
                return BadRequest();
            }
            var user = _userManager.FindByIdAsync(UserId).Result;
            if(user==null)
            {
                return View("Error");
            }

            var Result=_userManager.ConfirmEmailAsync(user, Token).Result;
            if(Result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
               return View();
            }
            //return RedirectToAction("Login");
        }
        public IActionResult Login(string ReturnUrl="/")
        {
            return View(new LoginViewModel
            {
                ReturnUrl = ReturnUrl
            }) ;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            _signInManager.SignOutAsync();
            var user = _userManager.FindByNameAsync(loginViewModel.UserName).Result;
            if(user==null)
            {
                ModelState.AddModelError("", "کاربر یافت نشد");
                return View(loginViewModel);
            }

            var Result=_signInManager.PasswordSignInAsync(user, loginViewModel.PassWord, loginViewModel.IsPersistent, true).Result;

            if(Result.Succeeded)
            {
                return Redirect(loginViewModel.ReturnUrl);
            }


           ModelState.AddModelError(string.Empty,"ورود شما با خطا مواجه شده است...!");

            return View();
        }

        public IActionResult SignOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel forgot)
        {
            if(!ModelState.IsValid)
            {
                return View(forgot);
            }
            var user = _userManager.FindByEmailAsync(forgot.Email).Result;
            if(user==null || _userManager.IsEmailConfirmedAsync(user).Result==false)
            {
                ViewBag.meesage = "ممکن است ایمیل وارد شده معتبر نباشد! و یا اینکه ایمیل خود را تایید نکرده باشید";
                return View();
            }
            var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;

            string CallBackUrl = Url.Action("ResetPassWord", "Account", new
            {
                UserId = user.Id,
                Token = token,
            }, protocol: Request.Scheme);

            string body = $"برای تنظیم مجدد کلمه عبور بر روی لینک زیر کلیک کنید<br/><a href={CallBackUrl}>Link Reset Password</a>";
            _emailServices.Execute(user.Email, body, "فراموشی رمز عبور");
            ViewBag.meesage = "لینک تنظیم مجدد کلمه عبور برای ایمیل شما ارسال شد";
            return View();
        }

        public IActionResult ResetPassWord(string UserId,string Token)
        {
            return View(new ResetPassWordViewModel
            {
                Token=Token,
                UserId=UserId,
            });
        }

        [HttpPost]
        public IActionResult ResetPassWord(ResetPassWordViewModel reset)
        {
            if(!ModelState.IsValid)           
                return BadRequest();

            if (reset.Password != reset.ConfirmPassword)
                return BadRequest();

            var user = _userManager.FindByIdAsync(reset.UserId).Result;
            if(user==null)
                return BadRequest();
                
            var Result = _userManager.ResetPasswordAsync(user, reset.Token,reset.Password).Result;

            if(Result.Succeeded)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            else
            {
                ViewBag.Error = Result.Errors;
                return View(reset);
            }
        }

        public IActionResult ResetPasswordConfirmation()
        {
            return RedirectToAction("Login","Account");
        }

        public IActionResult SetPhoneNumber()
        {
            return View();

        }

        //[HttpPost]
        //[Authorize]
        //public IActionResult SetPhoneNumber(SetPhoneNumberViewModel setPhoneNumber)
        //{
        //    var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
        //    var setresult=_userManager.SetPhoneNumberAsync(user, setPhoneNumber.PhoneNumber).Result;
        //    string code = _userManager.GenerateChangePhoneNumberTokenAsync(user, setPhoneNumber.PhoneNumber).Result;



        //}
    }
}
