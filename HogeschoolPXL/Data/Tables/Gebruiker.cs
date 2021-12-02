using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Data.Tables
{
    public class Gebruiker
    {
        [Required]
        public int GebruikerId { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]
        public string Email { get; set; }       

        public ICollection<Student> Students { get; set; }
        public ICollection<Lector> Lectors { get; set; }
    }
}
