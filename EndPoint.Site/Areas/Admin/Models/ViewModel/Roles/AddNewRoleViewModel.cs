using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Admin.Models.ViewModel.Roles
{
    public class AddNewRoleViewModel
    {
        
        [Required(ErrorMessage="نقش را وارد کنید")]
        [Display(Name="نام نقش")]
        public string Name { get; set; }


        [Display(Name = "توضیحات")]
        public string Description { get; set; }

    }
}
