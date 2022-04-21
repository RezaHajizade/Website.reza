using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Services.Common.Queries.GetMenuItem;
using WebSite.reza.Application.Services.Products.Commands.AddNewCategory;
using WebSite.reza.Application.Services.Products.Commands.AddNewProduct;
using WebSite.reza.Application.Services.Products.Commands.EditCategory;
using WebSite.reza.Application.Services.Products.Commands.RemoveCategory;
using WebSite.reza.Application.Services.Products.Commands.RemoveProduct;
using WebSite.reza.Application.Services.Products.Queries.GetAllCategories;
using WebSite.reza.Application.Services.Products.Queries.GetCategories;
using WebSite.reza.Application.Services.Products.Queries.GetProductDetailForAdmin;
using WebSite.reza.Application.Services.Products.Queries.GetProductForAdmin;
using WebSite.reza.Application.Services.Products.Queries.GetProductForSite;

namespace WebSite.reza.Application.Interfaces.FacadPatterns
{
    public interface IProductFacadForAdmin
    {
        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoryService GetCategoryService { get; }
        AddNewProductService AddNewProductService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }

        IRemoveCategoryService RemoveCategoryService { get; }

        IEditCategoryService EditCategoryService { get; }
        /// <summary>
        /// دریافت لیست محصولات
        /// </summary>
        IGetProductForAdminService GetProductForAdminService { get; }

        IGetProductDetailForAdmin GetProductDetailForAdmin { get; }

        IRemoveProduct RemoveProduct { get; }




    }
}
