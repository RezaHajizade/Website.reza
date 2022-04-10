using EndPoint.Site.Areas.Admin.Models.ViewModel.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Domain.Entities.Users;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public RolesController(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public IActionResult Index()
        {

            var role = _roleManager.Roles
                .Select(p=>new RoleListViewModel
                {
                    Id=p.Id,
                    Description=p.Description,
                    Name=p.Name,
                }).ToList();

            return View(role);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AddNewRoleViewModel addNewRole)
        {
            Role role = new Role()
            {
                Name = addNewRole.Name,
                Description = addNewRole.Description,
            };

            var result = _roleManager.CreateAsync(role).Result;

            if(result.Succeeded)
            {
                return RedirectToAction("index", "Roles", new { area = "Admin" });
            }
            ViewBag.Errors=result.Errors.ToList();
            return View(addNewRole);
        }

        public IActionResult Edit(string Id)
        {
            var role = _roleManager.FindByIdAsync(Id).Result;

            RoleEditViewModel roleEdit = new RoleEditViewModel()
            {
                Name =role.Name,
                Description = role.Description,
            };

            return View(roleEdit);
        }
        [HttpPost]
        public IActionResult Edit(RoleEditViewModel roleEdit)
        {
            var role = _roleManager.FindByIdAsync(roleEdit.Id).Result;

            role.Name = roleEdit.Name;
            role.Description = roleEdit.Description;

            var Result = _roleManager.UpdateAsync(role).Result;

            if(Result.Succeeded)
            {
                return RedirectToAction("Index", "Roles", new { area = "Admin" });
            }

            string message = "";
            foreach(var item in Result.Errors.ToList())
            {
                message += item.Description + Environment.NewLine;
            }
            TempData["Message"] = message;
            return View(roleEdit);
        }

        
        public IActionResult Delete(string Id)
        {
            var user = _roleManager.FindByIdAsync(Id).Result;

            var Result = _roleManager.DeleteAsync(user).Result;

            if(Result.Succeeded)
            {
                return RedirectToAction("Index", "Roles", new { area = "Admin" });
            }

            string message = "";
            foreach (var item in Result.Errors.ToList())
            {
                message += item.Description + Environment.NewLine;
            }
            TempData["Message"] = message;

            return RedirectToAction("Index", "Roles");
        }


    }
}
