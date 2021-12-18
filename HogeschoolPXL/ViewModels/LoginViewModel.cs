﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.ViewModels
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}