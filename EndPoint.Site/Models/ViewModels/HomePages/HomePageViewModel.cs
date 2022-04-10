using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.reza.Application.Services.Common.Queries.GetSlider;
using WebSite.reza.Application.Services.HomePages.Queries.GetHomePageImages;
using WebSite.reza.Application.Services.Products.Queries.GetProductForSite;

namespace EndPoint.Site.Models.ViewModels.HomePages
{
    public class HomePageViewModel
    {
        public List<SliderDto> Sliders { get; set; }
        public List<HomePageImageDto> PageImages { get; set; }
        public List<ProductForSiteDto> Camera { get; set; }
        public List<ProductForSiteDto> Mobile { get; set; }
        public List<ProductForSiteDto> Laptop { get; set; }

    }
}
