﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;
using WebSite.reza.Domain.Entities.Products;

namespace WebSite.reza.Application.Services.Products.Commands.AddNewCategory
{
    public interface IAddNewCategoryService
    {
        ResultDto Execute(long? ParentId, string Name);

    }
    public class AddNewCategoryService : IAddNewCategoryService
    {
        private readonly IDataBaseContext _context;

        public AddNewCategoryService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long? ParentId, string Name)
        {

            if (string.IsNullOrEmpty(Name))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "نام دسته بندی را وارد کنید",
                };
            }
            Category category = new Category()
            {
                Name = Name,
                ParentCategory = GetParent(ParentId),
            };
            _context.Categories.Add(category);
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت اضافه شد",
            };

        }
        private Category GetParent(long? ParentId)
        {
            return _context.Categories.Find(ParentId);
        }
    }



}
    
    

