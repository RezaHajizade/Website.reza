using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Application.Interfaces.FacadPatterns;
using WebSite.reza.Application.Services.Common.Queries.GetCategory;
using WebSite.reza.Application.Services.Common.Queries.GetMenuItem;
using WebSite.reza.Application.Services.HomePages.AddNewSlider;
using WebSite.reza.Application.Services.Products.Queries.GetProductDetailForsite;
using WebSite.reza.Application.Services.Products.Queries.GetProductForSite;

namespace WebSite.reza.Application.Services.Products.FacadePattern
{
    public class ProductFacadForSite : IProductFacadForSite
    {
        private readonly IDataBaseContext _context;
        

        public ProductFacadForSite(IDataBaseContext context)
        {
            _context = context;
        }

        private IGetProductForSiteService _getProductForSiteService;
        public IGetProductForSiteService GetProductForSiteService
        {
            get
            {
                return _getProductForSiteService = _getProductForSiteService ?? new GetProductForSiteService(_context);
            }
        }

        private IGetProductDetailForSiteService _getProductDetailForSiteService;

        public IGetProductDetailForSiteService GetProductDetailForSiteService
        {
            get
            {
                return _getProductDetailForSiteService = _getProductDetailForSiteService ?? new GetProductDetailForSiteService(_context);
            }
        }

        private IGetMenuItemService _getMenuItemService;
        public IGetMenuItemService GetMenuItemService
        {
            get
            {
                return _getMenuItemService = _getMenuItemService ?? new GetMenuItemService(_context);
            }
        }


        private IGetCategoryService _getCategoryService;
        public IGetCategoryService GetCategoryService
        {
            get
            {
                return _getCategoryService = _getCategoryService ?? new GetCategoryService(_context);
            }
        }

    }

}
