using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Application.Interfaces.FacadPatterns;
using WebSite.reza.Application.Services.Products.Commands.EditCategory;
using WebSite.reza.Application.Services.Products.Facade_Pattern;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Operator")]
    public class CategoriesController : Controller
    {
        private readonly IProductFacadForAdmin _productFacad;

        public CategoriesController(IProductFacadForAdmin productFacad)
        {
            _productFacad = productFacad;
        }


        public IActionResult Index(long? ParentId)
        
        {
            return View(_productFacad.GetCategoryService.Execute(ParentId).Data);
        }


        public IActionResult AddNewCategory(long? ParentId)
        {
            ViewBag.parentId = ParentId;

            return View();
        }
        [HttpPost]
        public IActionResult AddNewCategory(long? ParentId,string Name)
        {

            var result = _productFacad.AddNewCategoryService.Execute(ParentId,Name);
            return Json(result);
        }

        [HttpPost]
        public IActionResult RemoveCategory(long Id)
        {
            return Json(_productFacad.RemoveCategoryService.Execute(Id));
        }

        [HttpPost]
        public IActionResult EditCategory(long Id,string Name)
        {
            return Json(_productFacad.EditCategoryService.Execute(new EditCategoryDto
            {
                Id=Id,
                Name=Name,
            }));
        }
    }
}
