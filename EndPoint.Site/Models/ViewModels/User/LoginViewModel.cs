using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Models.ViewModels.User
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "ایمیل را وارد نمایید")]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string UserName { get; set; }
       
        [Required(ErrorMessage = "پسورد را وارد نمایید")]
        [DataType(DataType.Password)]
        [Display(Name = "پسورد")]
        public string PassWord { get; set; }

        [Display(Name = "مرا به خاطر به سپار")]
        public bool IsPersistent { get; set; } = false;

        public string ReturnUrl { get; set; }

    }
}
