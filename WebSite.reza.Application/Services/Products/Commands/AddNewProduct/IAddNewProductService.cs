using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Common.Dto;
using WebSite.reza.Domain.Entities.Products;

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
        public AddNewProductService(IDataBaseContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public ResultDto Execute(RequestAddNewProductDto request)
        {
            try
            {
                var category = _context.Categories.Find(request.CategoryId);
                Product product = new Product()
                {
                    Brand = request.Brand,
                    Description = request.Description,
                    Name = request.Name,
                    Price = request.Price,
                    Inventory = request.Inventory,
                    Category = category,
                    Displayed = request.Displayed,
                };
                _context.Products.Add(product);

                List<ProductImages> ProductImages = new List<ProductImages>();
                foreach (var item in request.Images)
                {
                    var uploadResult = UploadFile(item);
                    ProductImages.Add(new ProductImages
                    {
                        Product = product,
                        Src = uploadResult.FileNameAddress
                    });
                }
                _context.ProductImages.AddRange(ProductImages);


                List<ProductFeatures> productFeatures = new List<ProductFeatures>();
                foreach(var item in request.Features)
                {
                    productFeatures.Add(new ProductFeatures
                    {
                        Value = item.Value,
                        DisplayName = item.DisplayName,
                        Product = product
                    });
                }
                _context.ProductFeatures.AddRange(productFeatures);

                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول با موفقیت اضافه شد"
                };
            }
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطا رخ داده"
                };
            }
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
                    return new UploadDto
                    {
                        Status = false,
                        FileNameAddress = ""
                    };
                }

                string filename = DateTime.Now.Ticks.ToString() + file.FileName;
                var filepath = Path.Combine(uploadsRootFolder, filename);
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto
                {
                    FileNameAddress = folder + filename,
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
        public long CategoryId { get; set; }
        public bool Displayed { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<AddNewProduct_Features> Features { get; set; }
    }
    public class AddNewProduct_Features
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
