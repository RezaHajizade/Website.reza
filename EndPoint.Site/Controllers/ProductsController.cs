using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.FacadPatterns;
using WebSite.reza.Application.Services.Products.Queries.GetProductForSite;

namespace EndPoint.Site.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductFacadForAdmin _productFacadForAdmin;
        private readonly IProductFacadForSite _productFacadForSite;

        public ProductsController(IProductFacadForAdmin productFacadForAdmin, IProductFacadForSite productFacadForSite)
        {
            _productFacadForAdmin = productFacadForAdmin;
            _productFacadForSite = productFacadForSite;
        }

        public IActionResult Index(Ordering ordering,string SearchKey,long? CatId = null, int page=1,int pageSize=20 )
        {
            return View(_productFacadForSite.GetProductForSiteService.Execute(ordering, SearchKey,page,pageSize,CatId).Data);
        }

        public IActionResult Detail(long Id)
        {
            return View(_productFacadForSite.GetProductDetailForSiteService.Execute(Id).Data);
        }
    }
}
