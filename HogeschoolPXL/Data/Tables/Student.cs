using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Data.Tables
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        public int GebruikerId { get; set; }
        [Required]

        public Gebruiker Gebruiker { get; set; }
    }
}
