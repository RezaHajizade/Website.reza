using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;

namespace WebSite.reza.Application.Services.Products.Commands.RemoveCategory
{
    public interface IRemoveCategoryService
    {
        ResultDto Execute(long Id); 
    }

    public class RemoveCategoryService : IRemoveCategoryService
    {
        private readonly IDataBaseContext _Context;

        public RemoveCategoryService(IDataBaseContext context)
        {
            _Context = context;
        }

        public ResultDto Execute(long Id)
        {
            var category = _Context.Categories.Find(Id);
            if(category==null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "هیچ دسته بندی یافت نشد",
                };
            }
           // _Context.Categories.Remove(category);
            category.RemoveTime = DateTime.Now;
            category.IsRemoved = true;
            _Context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت حذف شد"
            };


        }
    }
}
