using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Data.Tables
{
    public class Student
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int GebruikerId { get; set; }    

        public Gebruiker Gebruiker { get; set; }
        public ICollection<Inschrijving> Inschrijvingen { get; set; }
    }
}
