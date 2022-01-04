﻿using HogeschoolPXL.Data.Tables;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Data
{
    public class SeedData
    {
        public static async Task EnsurePopulatedAsync(IApplicationBuilder app)
        {
            ApplicationDBContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDBContext>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Gebruikers.Any())//&& !context.Students.Any() && !context.Lectors.Any() && !context.Handboeken.Any() && !context.VakLectors.Any() && !context.Vakken.Any() && !context.AcademieJaren.Any() && !context.Inschrijvingen.Any())
            {
                var gebruiker = new Gebruiker { Naam = "Ayar", Voornaam = "Emre", Email = "emre@hotmail.com" };
                var gebruiker2 = new Gebruiker { Naam = "Bob", Voornaam = "Marley", Email = "bob@hotmail.com" };
                var gebruiker3 = new Gebruiker { Naam = "Kristof", Voornaam = "Palmears", Email = "kristof@hotmail.com" };
                context.Gebruikers.AddRange(gebruiker, gebruiker2, gebruiker3);
                context.SaveChanges();
                var student = new Student { Gebruiker = gebruiker };
                var student2 = new Student { Gebruiker = gebruiker2 };
                context.Students.AddRange(student, student2);
                context.SaveChanges();
                var lector = new Lector { Gebruiker = gebruiker3 };
                context.Lectors.AddRange(lector);
                context.SaveChanges();
                var handboek = new Handboek { Titel = "C# Web1", Afbeelding = "C# Web1", KostPrijs = 20.99M, UitgifteDatum = DateTime.ParseExact("2021-07-21", "yyyy-MM-dd", null) };
                context.Handboeken.AddRange(handboek);
                context.SaveChanges();
                var vak = new Vak { VakNaam = "C# Web 1", StudiePunten = 6, Handboek = handboek };
                context.Vakken.AddRange(vak);
                context.SaveChanges();
                var vaklector = new VakLector { Vak = vak, Lector = lector };
                context.VakLectors.AddRange(vaklector);
                context.SaveChanges();
                var academiejaar = new AcademieJaar { StartDatum = DateTime.ParseExact("2021-09-20", "yyyy-MM-dd", null) };
                context.AcademieJaren.AddRange(academiejaar);
                context.SaveChanges();
                var inschrijving = new Inschrijving { StudentId = student.StudentId, VakLectorId = vaklector.VakLectorId, AcademieJaar = academiejaar };
                context.Inschrijvingen.AddRange(inschrijving);
                context.SaveChanges();
            }
            await CreateRolesAsync(context, roleManager);
        }
        public static class Roles
        {
            public static string Admin = "Admin";
        }
        private static async Task CreateRolesAsync(ApplicationDBContext context, RoleManager<IdentityRole> roleManager)
        {
            if (!context.Roles.Any())
            {
                await CreateRolesAsync(roleManager, Roles.Admin);
            }
        }
        private static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager, string role)
        {
            IdentityRole identityRole = new IdentityRole(role);
            await roleManager.CreateAsync(identityRole);
        }
    }
}
