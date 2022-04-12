using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;

namespace WebSite.reza.Application.Services.Products.Commands.EditCategory
{
    public interface IEditCategoryService
    {
        ResultDto Execute(EditCategoryDto edit);
    }


    public class EditCategoryService : IEditCategoryService
    {
        private readonly IDataBaseContext _context;

        public EditCategoryService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(EditCategoryDto edit)
        {
            var category = _context.Categories.Find(edit.Id);

            if(category ==null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "دسته بندی یافت نشد"
                };
            }

            category.Name = edit.Name;
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "ویرایش کاربر انجام شد"
            };
          
        }
    }
    public class EditCategoryDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

    }
        


}
