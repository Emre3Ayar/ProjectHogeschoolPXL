using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.ViewModels
{
    public class RegisterResult
    {
        public bool Succeeded { get; set; }
        public List<string> Errors = new List<string>();
    }
}
