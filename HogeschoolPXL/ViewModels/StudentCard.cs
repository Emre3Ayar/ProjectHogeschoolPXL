using HogeschoolPXL.Data;
using HogeschoolPXL.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.ViewModels
{
    public class StudentCard
    {
        public Student Student { get; set; }
        public int StudentId { get; set; }

        public int GebruikerId { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Email { get; set; }

        public StudentCard(ApplicationDBContext context, Student student)
        {
            StudentId = student.StudentId;
            GebruikerId = student.GebruikerId;
            Naam = student.Gebruiker.Naam;
            Voornaam = student.Gebruiker.Voornaam;
            Email = student.Gebruiker.Email;
            Student = student;
        }
    }
}
