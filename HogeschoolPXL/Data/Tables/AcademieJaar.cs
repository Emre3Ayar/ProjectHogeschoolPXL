using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Data.Tables
{
    public class AcademieJaar
    {
        public int AcademieJaarId { get; set; }
        [Required]
        public DateTime StartDatum { get; set; }

        public ICollection<Inschrijving> Inschrijvingen { get; set; }
    }
}
