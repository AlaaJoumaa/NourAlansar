using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NourAnsar.Website.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessageResourceName = "MSG_IncorrectLogin",ErrorMessageResourceType =typeof(Resources.SharedResources))]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "MSG_IncorrectLogin", ErrorMessageResourceType = typeof(Resources.SharedResources))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
