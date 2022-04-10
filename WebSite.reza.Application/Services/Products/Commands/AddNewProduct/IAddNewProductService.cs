using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;
using WebSite.reza.Domain.Entities.Products;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WebSite.reza.Application.Services.Products.Commands.AddNewProduct
{
    public interface IAddNewProductService
    {
        ResultDto Execute(RequestAddNewProductDto request);
    }

    public class AddNewProductService : IAddNewProductService
    {
        private readonly IDataBaseContext _context;
        private readonly IWebHostEnvironment _environment;

        public AddNewProductService(IWebHostEnvironment environment, IDataBaseContext context )
        {
            _context = context;
            _environment = environment;
        }

        public ResultDto Execute(RequestAddNewProductDto request)
        {
            var category = _context.Categories.Find(request.CategoryId);

            Product product = new Product()
            {
                Name = request.Name,
                Brand = request.Brand,
                Description = request.Description,
                Price = request.Price,
                Displayed = request.Displayed,
                Inventory = request.Inventory,
                Category = category,
            };
            _context.Products.Add(product);

            List<ProductImages> productImages = new List<ProductImages>();
            foreach (var item in request.Images)
            {
                var uploadedResult = UploadFile(item);
                productImages.Add(new ProductImages
                {
                    Product = product,
                    Src = uploadedResult.FileNameAddress,
                });
                    
            }
            _context.ProductImages.AddRange(productImages);

            List<ProductFeatures> productFeatures = new List<ProductFeatures>();
            foreach(var item in request.Features)
            {
                productFeatures.Add (new ProductFeatures{
                    DisplayName=item.DisplayName,
                    Value=item.Value,
                    Product=product,
                });
            }
            _context.ProductFeatures.AddRange(productFeatures);

            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "محصول با موفقیت به محصولات فروشگاه اضافه شد!",
            };
        }
        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\ProductImages\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }

  

    public class UploadDto
    {
        public long Id { get; set; }
        public bool Status { get; set; }
        public string FileNameAddress { get; set; }
    }
    public class RequestAddNewProductDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
        //فیلد زیر یک آیدی میگیره که آیدی کتگوری آیدی هست که قبلا در سیستم اضافه کردیم
        public long CategoryId { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<AddNewProduct_Features> Features { get; set; }
    }
    public class AddNewProduct_Features
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
