using HogeschoolPXL.Data.Tables;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDBContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDBContext>();
            if (!context.Gebruikers.Any() && !context.Students.Any() && !context.Lectors.Any())
            {
                var gebruiker = new Gebruiker { Naam = "Ayar", Voornaam = "Emre", Email = "emre@hotmail.com" };
                var gebruiker2 = new Gebruiker { Naam = "Bob", Voornaam = "Marley", Email = "bob@hotmail.com" };
                var gebruiker3 = new Gebruiker { Naam = "Kristof", Voornaam = "Palmears", Email = "kristof@hotmail.com" };
                context.Gebruikers.AddRange(gebruiker, gebruiker2, gebruiker3);
                var student = new Student { Gebruiker = gebruiker };
                var student2 = new Student { Gebruiker = gebruiker2 };
                context.Students.AddRange(student, student2);
                var lector = new Lector { Gebruiker = gebruiker3 };
                context.Lectors.AddRange(lector);
                context.SaveChanges();
            }
        }
    }
}
