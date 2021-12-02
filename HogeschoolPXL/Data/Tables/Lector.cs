using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Data.Tables
{
    public class Lector
    {
        [Required]
        public int LectorId { get; set; }
        [Required]
        public int GebruikerId { get; set; }
        

        public Gebruiker Gebruiker { get; set; }
        public ICollection<VakLector> VakLectors { get; set; }
    }
}
