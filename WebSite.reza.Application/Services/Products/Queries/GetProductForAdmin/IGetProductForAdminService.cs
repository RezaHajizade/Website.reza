using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common;
using WebSite.reza.Common.Dto;

namespace WebSite.reza.Application.Services.Products.Queries.GetProductForAdmin
{
    public interface IGetProductForAdminService
    {
        ResultDto<ProductForAdminDto> Execute(int Page = 1, int PageSize = 20);
    }

    public class GetProductForAdminService : IGetProductForAdminService
    {
        private readonly IDataBaseContext _context; 

        public GetProductForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
            
        public ResultDto<ProductForAdminDto> Execute(int Page = 1, int PageSize = 20)
        {
            int rowCount = 0;
            var products = _context.Products
                        .Include(p => p.Category)
                        .ToPaged(Page, PageSize, out rowCount)
                        .Select(p => new ProductsFormAdminList_Dto
                        {
                            Id = p.Id,
                            Brand = p.Brand,
                            Category = p.Category.Name,
                            Description = p.Description,
                            Name = p.Name,
                            Displayed = p.Displayed,
                            Inventory = p.Inventory,
                            Price = p.Price
                        }).ToList();
            return new ResultDto<ProductForAdminDto>()
            {
                Data =new ProductForAdminDto()
                {
                    products = products,
                    CurrentPage = Page,
                    PageSize = PageSize,
                    RowCount = rowCount
                },
                IsSuccess = true,
                Message = "",
            };
                        
        }
    }

    public class ProductForAdminDto
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<ProductsFormAdminList_Dto> products { get; set; }
    }

    public class ProductsFormAdminList_Dto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
    }
}
