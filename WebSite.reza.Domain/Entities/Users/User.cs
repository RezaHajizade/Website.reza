using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.reza.Domain.Entities.Commons;

using WebSite.reza.Domain.Entities.Orders;

namespace WebSite.reza.Domain.Entities.Users
{
    public class User:IdentityUser
    {
      
        public string FullName { get; set; }
    
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string UserRoles { get; set; }

        public DateTime InsertTime { get; set; } = DateTime.Now;

        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; } = false;
        public DateTime? RemoveTime { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }


    
}
