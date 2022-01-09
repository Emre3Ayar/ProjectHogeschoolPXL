using HogeschoolPXL.Data.Tables;
using HogeschoolPXL.Helpers;
using HogeschoolPXL.Models;
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
            UserManager<CustomIdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<CustomIdentityUser>>();
            
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
                var handboek2 = new Handboek { Titel = "C# Mobile1", Afbeelding = "C# Mobile1", KostPrijs = 21.99M, UitgifteDatum = DateTime.ParseExact("2021-08-23", "yyyy-MM-dd", null) };
                var handboek3 = new Handboek { Titel = "Werkplekleren 3", Afbeelding = "Werkplekleren 3", KostPrijs = 19.99M, UitgifteDatum = DateTime.ParseExact("2021-04-20", "yyyy-MM-dd", null)};
                var handboek4 = new Handboek { Titel = "Data Advanced", Afbeelding = "Data Advanced", KostPrijs = 13.89M, UitgifteDatum = DateTime.ParseExact("2021-04-22", "yyyy-MM-dd", null) };
                var handboek5 = new Handboek { Titel = "Project management", Afbeelding = "Project management", KostPrijs = 15.89M, UitgifteDatum = DateTime.ParseExact("2021-04-23", "yyyy-MM-dd", null) };
                context.Handboeken.AddRange(handboek, handboek2, handboek3, handboek4, handboek5);
                context.SaveChanges();
                var vak = new Vak { VakNaam = "C# Web 1", StudiePunten = 6, Handboek = handboek };
                var vak2 = new Vak { VakNaam = "C# Mobile 1", StudiePunten = 12, Handboek = handboek2 };
                var vak3 = new Vak { VakNaam = "Werkplekleren 3", StudiePunten = 10, Handboek = handboek3 };
                var vak4 = new Vak { VakNaam = "Data Advanced", StudiePunten = 6, Handboek = handboek4 };
                var vak5 = new Vak { VakNaam = "Project management", StudiePunten = 6, Handboek = handboek5 };
                context.Vakken.AddRange(vak, vak2, vak3,vak4,vak5);
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
            if (!context.Roles.Any())
            {
                var role = new IdentityRole(RoleHelper.AdminRole);
                await roleManager.CreateAsync(role);

                role = new IdentityRole(RoleHelper.LectorRole);
                await roleManager.CreateAsync(role);

                role = new IdentityRole(RoleHelper.StudentRole);
                await roleManager.CreateAsync(role);

                var user = new CustomIdentityUser();
                user.Email = "admin@pxl.be";
                user.UserName = user.Email;
                user.RoleName = RoleHelper.AdminRole;

                var user2 = new CustomIdentityUser();
                user2.Email = "student@pxl.be";
                user2.UserName = user2.Email;
                user2.RoleName = RoleHelper.StudentRole;

                var user3 = new CustomIdentityUser();
                user3.Email = "lector@pxl.be";
                user3.UserName = user3.Email;
                user3.RoleName = RoleHelper.LectorRole;

                var result = await userManager.CreateAsync(user, "Admin456!");
                var result2 = await userManager.CreateAsync(user2, "Student123!");
                var result3 = await userManager.CreateAsync(user3, "Lector123!");
                if (result.Succeeded && result2.Succeeded)
                {
                    role = await roleManager.FindByNameAsync(RoleHelper.AdminRole);
                    if (role != null)
                    {
                        await userManager.AddToRoleAsync(user, role.Name);
                    }
                }
            }
            //await CreateRolesAsync(context, roleManager);
            //await CreateIdentityRecordAsync(context,userManager, roleManager);
        }

        //public static class Roles
        //{
        //    public static string AdminRole = "ADMIN";
        //    public static string StudentRole = "STUDENT";
        //    public static string LectorRole = "LECTOR";
        //}
        //private static async Task CreateRolesAsync(ApplicationDBContext context, RoleManager<IdentityRole> roleManager)
        //{
        //    if (!context.Roles.Any())
        //    {
        //        await CreateRoleAsync(roleManager, Roles.AdminRole);
        //        await CreateRoleAsync(roleManager, Roles.StudentRole);
        //        await CreateRoleAsync(roleManager, Roles.LectorRole);
        //    }
        //}
        //private static async Task CreateRoleAsync(RoleManager<IdentityRole> roleManager, string role)
        //{
        //    if (!await roleManager.RoleExistsAsync(role))
        //    {
        //        IdentityRole identityRole = new IdentityRole(role);
        //        await roleManager.CreateAsync(identityRole);
        //    }         
        //}
        //private static async Task CreateIdentityRecordAsync(ApplicationDBContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        //{
            //Als de student email niet gevonden kan worden dan admin email niet aangemaakt
            //var email = "student@pxl.be";
            //var UserName = "Emre";
            //var email2 = "admin@pxl.be";
            //var UserName2 = "Admin";
            //if (await userManager.FindByEmailAsync(email) == null && await userManager.FindByNameAsync(UserName) == null)
            //{
                //await CreateRolesAsync(context, roleManager);
                //var password = "Student123!";
                //var password2 = "Admin456!";
                //var identityUser = new IdentityUser() { Email = email, UserName = UserName };
                //var identityUser2 = new IdentityUser() { Email = email2, UserName = UserName2 };
                //var result = await userManager.CreateAsync(identityUser, password);
                //var result2 = await userManager.CreateAsync(identityUser2, password2);
                //if (result.Succeeded)
                //{
                //    await userManager.AddToRoleAsync(identityUser, Roles.StudentRole);
                //}
                //else if (result2.Succeeded)
                //{
                //    await userManager.AddToRoleAsync(identityUser2, Roles.AdminRole);
                //}
            //}
        //}
    }
}
