using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Services.Common.Queries.GetCategory;
using WebSite.reza.Application.Services.Common.Queries.GetMenuItem;
using WebSite.reza.Application.Services.HomePages.AddNewSlider;
using WebSite.reza.Application.Services.Products.Queries.GetProductDetailForsite;
using WebSite.reza.Application.Services.Products.Queries.GetProductForSite;

namespace WebSite.reza.Application.Interfaces.FacadPatterns
{
   public  interface IProductFacadForSite
    {
        IGetProductForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }
        IGetMenuItemService GetMenuItemService { get; }
        IGetCategoryService GetCategoryService { get; }
       
    }
}
