﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        public string RoleId { get; set; }
    }
}
