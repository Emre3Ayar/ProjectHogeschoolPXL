using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Models
{
    public class CustomIdentityUser : IdentityUser
    {
        public string RoleName { get; set; }
    }
}
