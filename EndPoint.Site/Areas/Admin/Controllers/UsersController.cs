using EndPoint.Site.Areas.Admin.Models.ViewModel;
using EndPoint.Site.Areas.Admin.Models.ViewModel.Roles;
using EndPoint.Site.Models.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;
using WebSite.reza.Domain.Entities.Users;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IDataBaseContext _context;
        public UsersController(UserManager<User> userManager, RoleManager<Role> roleManager, IDataBaseContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users
                .Select(p => new UserListViewModel
                {
                    FullName = p.FullName,
                    Email = p.Email,
                    Id = p.Id,
                    UserName = p.UserName,
                    IsActive=p.IsActive                    
                }).ToList();

            return View(users);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_context.Role.ToList(),"Name","Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserCreateViewModel userCreateViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(userCreateViewModel);
            }


            User newuser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FullName = userCreateViewModel.FullName,
                Email =userCreateViewModel.Email,
                UserName = userCreateViewModel.Email,
                UserRoles=userCreateViewModel.UserRoles,
            };

            var role = _roleManager.FindByNameAsync(userCreateViewModel.UserRoles);
           
            var Result = _userManager.CreateAsync(newuser, userCreateViewModel.Password).Result;
            if(Result.Succeeded)
            {

                // "اینجا آیدی رول رو میدید که میخوای بهش بدی
             //  var roles= _userManager.AddToRolesAsync(newuser,).Result;
              


                return RedirectToAction("Index", "Users", new { area = "Admin" });             
            }

            string message = "";
            foreach (var item in Result.Errors.ToList())
            {
                message += item.Description + Environment.NewLine;
            }
            TempData["Message"] = message;
            return View(userCreateViewModel);

        }

        public IActionResult Edit(string Id)
        {
            var user = _userManager.FindByIdAsync(Id).Result;

            UserEditViewModel userEdit = new UserEditViewModel()
            {
                Email = user.Email,
                FullName = user.FullName,
                UserName = user.UserName,
            };

            return View(userEdit);
        }
        [HttpPost]
        public IActionResult Edit(UserEditViewModel userEdit)
        {
            var user = _userManager.FindByIdAsync(userEdit.Id).Result;

            user.FullName = userEdit.FullName;
            user.Email = userEdit.Email;
            user.UserName = userEdit.Email;

            var Result = _userManager.UpdateAsync(user).Result;

            if(Result.Succeeded)
            {
                return RedirectToAction("Index", "Users", new { area = "Admin" });
            }

            string message = "";
            foreach (var item in Result.Errors.ToList())
            {
                message += item.Description + Environment.NewLine;
            }
            TempData["Message"] = message;
            return View(userEdit);

        }
        [HttpGet]
        public IActionResult Delete(string Id)
        {
            var user = _userManager.FindByIdAsync(Id).Result;

            var Result = _userManager.DeleteAsync(user).Result;

            if(Result.Succeeded)
            {
                return RedirectToAction("Index", "Users", new { area = "Admin" });
            }


            string message = "";
            foreach (var item in Result.Errors.ToList())
            {
                message += item.Description + Environment.NewLine;
            }
            TempData["Message"] = message;

            return RedirectToAction("Index", "Users");

        }
        [HttpGet]
        public IActionResult AddUserRole(string Id)
        {
            var user = _userManager.FindByIdAsync(Id).Result;
            var roles = new List<SelectListItem>(
                _roleManager.Roles.Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Name
                }).ToList());

           
            return View(new AddUserRoleViewModel
            {
                Id = Id,
                Roles = roles,
                Email=user.Email,
                FullName=user.FullName,
            });
        }
        [HttpPost]
        public IActionResult AddUserRole(AddUserRoleViewModel newRole)
        {
            var user = _userManager.FindByIdAsync(newRole.Id).Result;

            var Result=_userManager.AddToRoleAsync(user, newRole.Role).Result;

            if(Result.Succeeded)
            {
               
                return RedirectToAction("UserRoles", "Users", new {Id=user.Id ,area = "admin" });

            }
            return View(newRole);
        }

        public async Task<IActionResult> UserRoles(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            var roles = await _userManager.GetRolesAsync(user);

            ViewBag.userInfo = $"{user.FullName}  باایمیل:{user.Email}";

            return View(roles);
        }

        
    }




}
