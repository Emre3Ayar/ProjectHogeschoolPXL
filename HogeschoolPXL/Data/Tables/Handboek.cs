using HogeschoolPXL.CustomModelValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Data.Tables
{
    public class Handboek
    {
        [Required(ErrorMessage = "Error HandboekId")]
        public int HandboekId { get; set; }
        [Required(ErrorMessage = "Error HandboekTitel")]
        public string Titel { get; set; }
        [Required(ErrorMessage = "Error Kostprijs")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal KostPrijs { get; set; }
        [Required]
        [CustomDate]
        public DateTime UitgifteDatum { get; set; }
        [Required(ErrorMessage = "Error Afbeelding")]
        public string Afbeelding { get; set; }      

        public ICollection<Vak> Vakken { get; set; }
    }
}
