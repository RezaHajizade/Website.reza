using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Admin.Models.ViewModel
{
    public class UserListViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
    }
}
