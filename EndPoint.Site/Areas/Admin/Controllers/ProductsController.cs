using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.FacadPatterns;
using WebSite.reza.Application.Services.Products.Commands.AddNewProduct;
using WebSite.reza.Domain.Entities.Products;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductFacadForAdmin _productFacad;

        public ProductsController(IProductFacadForAdmin productFacad)
        {
            _productFacad = productFacad;
        }

        public IActionResult Index(int Page=1,int PageSize=20)
        {
            return View(_productFacad.GetProductForAdminService.Execute(Page,PageSize).Data);
        }

        [HttpGet]
        public IActionResult AddNewProduct()
        {
            ViewBag.Categories = new SelectList(_productFacad.GetAllCategoriesService.Execute().Data,"Id","Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddNewProduct(RequestAddNewProductDto request, List<AddNewProduct_Features> features)
        {

            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            request.Images = images;
            request.Features = features;

            return Json(_productFacad.AddNewProductService.Execute(request));
        }
        
        public IActionResult Detail(long Id)
        {
            return View(_productFacad.GetProductDetailForAdmin.Execute(Id).Data);
        }
        public IActionResult RemoveProduct(long Id)
        {
            return Json(_productFacad.RemoveProduct.Execute(Id));
        }
    }
}
