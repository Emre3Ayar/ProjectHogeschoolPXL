using HogeschoolPXL.Data.Tables;
using HogeschoolPXL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student = HogeschoolPXL.Data.Tables.Student;

namespace HogeschoolPXL.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lector> Lectors { get; set; }

        public DbSet<VakLector> VakLectors { get; set; }
        public DbSet<Handboek> Handboeken { get; set; }
        public DbSet<Inschrijving> Inschrijvingen { get; set; }
        public DbSet<AcademieJaar> AcademieJaren { get; set; }
        public DbSet<Vak> Vakken { get; set; }
    }
}
