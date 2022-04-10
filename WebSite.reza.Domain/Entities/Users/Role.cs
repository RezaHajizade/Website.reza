using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using WebSite.reza.Domain.Entities.Commons;

namespace WebSite.reza.Domain.Entities.Users
{
    public class Role: IdentityRole
    {
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public DateTime InsertTime { get; set; } = DateTime.Now;

        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; } = false;
        public DateTime? RemoveTime { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
