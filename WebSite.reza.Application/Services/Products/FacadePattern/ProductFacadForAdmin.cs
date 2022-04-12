using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Application.Interfaces.FacadPatterns;
using WebSite.reza.Application.Services.Common.Queries.GetMenuItem;
using WebSite.reza.Application.Services.Products.Commands.AddNewCategory;
using WebSite.reza.Application.Services.Products.Commands.AddNewProduct;
using WebSite.reza.Application.Services.Products.Commands.EditCategory;
using WebSite.reza.Application.Services.Products.Commands.RemoveCategory;
using WebSite.reza.Application.Services.Products.Queries.GetAllCategories;
using WebSite.reza.Application.Services.Products.Queries.GetCategories;
using WebSite.reza.Application.Services.Products.Queries.GetProductDetailForAdmin;
using WebSite.reza.Application.Services.Products.Queries.GetProductForAdmin;

namespace WebSite.reza.Application.Services.Products.Facade_Pattern
{
    public class ProductFacadForAdmin : IProductFacadForAdmin
    {
        private readonly IDataBaseContext _context;
        private readonly IWebHostEnvironment _environment;
        public ProductFacadForAdmin(IWebHostEnvironment environment, IDataBaseContext context)
        {
            _context = context;
            _environment = environment;
        }


        private AddNewCategoryService _addNewCategory;
        public AddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(_context);
            }
        }

        private IGetCategoryService _getCategoryService;
        public IGetCategoryService GetCategoryService
        {
            get
            {
                return _getCategoryService = _getCategoryService ?? new
                    GetCategoryService(_context);
            }
        }

        private IRemoveCategoryService _removeCategoryService;
        public IRemoveCategoryService RemoveCategoryService
        {
            get
            {
                return _removeCategoryService = _removeCategoryService ?? new RemoveCategoryService(_context);
            }
        }

        private IEditCategoryService _editCategoryService; 
        public IEditCategoryService EditCategoryService
        {
            get
            {
                return _editCategoryService = _editCategoryService ?? new EditCategoryService(_context);
            }
        }

        private AddNewProductService _addNewProductService;
        public AddNewProductService AddNewProductService
        {
            get
            {
                return _addNewProductService = _addNewProductService ?? new AddNewProductService(_environment, _context);
            }
        }

        private IGetAllCategoriesService _getAllCategoriesService;
        public IGetAllCategoriesService GetAllCategoriesService
        {
            get
            {
                return _getAllCategoriesService = _getAllCategoriesService ?? new GetAllCategoriesService(_context);
            }
        }

        private IGetProductForAdminService _getProductForAdminService;
        public IGetProductForAdminService GetProductForAdminService
        {
            get
            {
                return _getProductForAdminService = _getProductForAdminService ?? new GetProductForAdminService(_context);
            }
        }

        private IGetProductDetailForAdmin _getProductDetailForAdmin;

        public IGetProductDetailForAdmin GetProductDetailForAdmin
        {
            get
            {
                return _getProductDetailForAdmin = _getProductDetailForAdmin ?? new GetProductDetailForAdmin(_context);
            }
        }


    }
}
