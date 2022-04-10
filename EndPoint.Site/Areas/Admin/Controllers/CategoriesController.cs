using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Application.Interfaces.FacadPatterns;
using WebSite.reza.Application.Services.Products.Facade_Pattern;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Operator")]
    public class CategoriesController : Controller
    {
        private readonly IProductFacadForAdmin _productFacad;

        public CategoriesController(IProductFacadForAdmin productFacad)
        {
            _productFacad = productFacad;
        }


        //public IActionResult Index()
        //{
        //    return View(_context.Categories.Name)
        //}


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
    }
}
