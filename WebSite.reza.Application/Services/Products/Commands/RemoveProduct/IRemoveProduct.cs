using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;

namespace WebSite.reza.Application.Services.Products.Commands.RemoveProduct
{
    public interface IRemoveProduct
    {
        ResultDto Execute(long Id);
    }
    public class RemoveProduct : IRemoveProduct
    {
        private readonly IDataBaseContext _context;

        public RemoveProduct(IDataBaseContext context)
        {
            _context = context;
        }


        public ResultDto Execute(long Id)
        {
            var Product = _context.Products.Find(Id);
            if(Product==null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "هیچ محصولی یافت نشد",
                };

            }

            Product.IsRemoved = true;
            Product.RemoveTime = DateTime.Now;
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "محصول با موفقیت حذف شد",
            };

        }
    }

}
