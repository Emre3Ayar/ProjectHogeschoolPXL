using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Data.Tables
{
    public class Inschrijving
    {
        public int InschrijvingId { get; set; }
        [Required]
        public int StudentId { get; set; }

        public int? VakLectorId { get; set; }

        public int AcademieJaarId { get; set; }


        public VakLector VakLector { get; }
        public Student Student { get; set; }
        public AcademieJaar AcademieJaar { get; set; }
    }
}
