using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;

namespace WebSite.reza.Application.Services.Products.Queries.GetProductDetailForsite
{
    public interface IGetProductDetailForSiteService
    {
        ResultDto<ProductDetailForSiteDto> Execute(long Id);
    }

    public class GetProductDetailForSiteService : IGetProductDetailForSiteService
    {
        private readonly IDataBaseContext _context;

        public GetProductDetailForSiteService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ProductDetailForSiteDto> Execute(long Id)
        {
            var Product = _context.Products
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductFeatures)
                .Where(p => p.Id == Id).FirstOrDefault();


            if (Product == null)
            {
                throw new Exception("Product Not Found.....");
            }

            return new ResultDto<ProductDetailForSiteDto>()
            {
                Data = new ProductDetailForSiteDto
                {
                    Id=Product.Id,
                    Brand=Product.Brand,
                    Description=Product.Description,
                    Price=Product.Price,
                    Title=Product.Name,
                    Category=$"{ Product.Category.ParentCategory.Name}-{Product.Category.Name}",
                    Images=Product.ProductImages.Select(p=>p.Src).ToList(),
                    Features=Product.ProductFeatures.Select(p=>new ProductDetailForSite_FeaturesDto
                    {
                        DisplayName=p.DisplayName,
                        Value=p.Value,
                    }).ToList(),
                    
                },
                IsSuccess=true,
                Message="",
                
            };


        }

       
    }

    public class ProductDetailForSiteDto
    {
        public long  Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public List<String> Images { get; set; }
        public List<ProductDetailForSite_FeaturesDto> Features { get; set; }
    }

    public class ProductDetailForSite_FeaturesDto
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }

    }
}
