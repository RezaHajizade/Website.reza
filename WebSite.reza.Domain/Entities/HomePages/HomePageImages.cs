using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Domain.Entities.Commons;

namespace WebSite.reza.Domain.Entities.HomePages
{
    public class HomePageImages:BaseEntity
    {
        public string Link { get; set; }
        public string Src { get; set; }
        public ImageLocation ImageLocation { get; set; }

    }

    public enum ImageLocation
    {
        L1=0,
        L2=1,
        R1=3,
        CenterFullScreen=4,
        G1=5,
        G2=6,
    }
}
