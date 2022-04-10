using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Application.Services.Common.Queries.GetCategory;
using WebSite.reza.Common.Dto;

namespace WebSite.reza.Application.Services.Products.Queries.GetCategories
{
    public interface IGetCategoriesService
    {
        ResultDto<List<CategoriesDto>> Execute(long? parentId);
    }

    public class GetCategoryService : IGetCategoriesService
    {
        private readonly IDataBaseContext _context;

        public GetCategoryService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<CategoriesDto>> Execute(long? parentId)
        {
            var category = _context.Categories
                .Include(p => p.ParentCategory)
                .Include(P => P.SubCategories)
                .Where(p => p.ParentCategoryId == parentId)
                .ToList()
                .Select(p => new CategoriesDto
                {
                    //Id = p.Id,
                    Name = p.Name,
                    HasChild = p.SubCategories.Count() > 0 ? true : false,
                    Parent=p.ParentCategory !=null 
                    
                });
        }
    }

    public class CategoriesDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public ParentCategoryDto Parent { get; set; }
    }

    public class ParentCategoryDto
    {
        public long Id { get; set; }
        public string name { get; set; }
    }
}
