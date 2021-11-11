using HogeschoolPXL.Data;
using HogeschoolPXL.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.ViewModels
{
    public class LectorCard
    {
        public Lector Lector { get; set; }
        public int LectorId { get; set; }

        public int GebruikerId { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Email { get; set; }

        public LectorCard(ApplicationDBContext context, Lector lector)
        {
            LectorId = lector.LectorId;
            GebruikerId = lector.GebruikerId;
            Naam = lector.Gebruiker.Naam;
            Voornaam = lector.Gebruiker.Voornaam;
            Email = lector.Gebruiker.Email;
            Lector = lector;
        }
    }
}
