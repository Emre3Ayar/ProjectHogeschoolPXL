using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required]
        public string RoleName { get; set; }
        [Compare("Password", ErrorMessage = "Password moet overeenkomen!")]
        public string ConfirmPassword { get; set; }
    }
}
