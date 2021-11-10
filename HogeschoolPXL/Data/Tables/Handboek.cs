using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Data.Tables
{
    public class Handboek
    {
        public int HandboekId { get; set; }
        [Required]       
        public string Titel { get; set; }

        public double KostPrijs { get; set; }

        public DateTime UitgifteDatum { get; set; }

        public string Afbeelding { get; set; }

        public ICollection<Vak> Vakken { get; set; }
    }
}
