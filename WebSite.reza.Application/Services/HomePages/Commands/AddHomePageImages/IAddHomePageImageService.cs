using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Application.Interfaces.Contexts;
using WebSite.reza.Application.Services.Products.Commands.AddNewProduct;
using WebSite.reza.Common.Dto;
using WebSite.reza.Domain.Entities.HomePages;

namespace WebSite.reza.Application.Services.HomePages.Commands.AddHomePageImages
{
    public interface IAddHomePageImageService
    {
        ResultDto Execute(requestAddHomePageImagesDto request);
    }

    public class AddHomePageImageService : IAddHomePageImageService
    {
        private readonly IDataBaseContext _context;
        private readonly IWebHostEnvironment _environment;

        public AddHomePageImageService(IDataBaseContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public ResultDto Execute(requestAddHomePageImagesDto request)
        {
            var resultUpload = UploadFile(request.file);
            HomePageImages homePage = new HomePageImages()
            {
                Link = request.Link,
                ImageLocation = request.ImageLocation,
                Src = resultUpload.FileNameAddress,
            };
            _context.homePageImages.Add(homePage);
            _context.SaveChanges();
            return new ResultDto()
            { 
                IsSuccess = true 
            };

        }


        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\HomePages\Slider\";
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

    public class requestAddHomePageImagesDto
    {
        public IFormFile file { get; set; }
        public string Link { get; set; }
        public ImageLocation ImageLocation { get; set; }

    }
}
