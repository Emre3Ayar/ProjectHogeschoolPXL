using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Data.Tables
{
    public class Vak
    {
        public int VakId { get; set; }
        [Required]
        public string VakNaam { get; set; }

        public double StudiePunten { get; set; }

        public int HandboekId { get; set; }


        public ICollection<VakLector> VakLectors { get; set; }
        public Handboek Handboek { get; set; }
    }
}
