using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Data.Tables
{
    public class Gebruiker
    {
        public int GebruikerId { get; set; }
        [Required]
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Email { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
