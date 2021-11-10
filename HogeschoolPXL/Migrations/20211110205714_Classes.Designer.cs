﻿// <auto-generated />
using System;
using HogeschoolPXL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HogeschoolPXL.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20211110205714_Classes")]
    partial class Classes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HogeschoolPXL.Data.Tables.AcademieJaar", b =>
                {
                    b.Property<int>("AcademieJaarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("StartDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("AcademieJaarId");

                    b.ToTable("AcademieJaren");
                });

            modelBuilder.Entity("HogeschoolPXL.Data.Tables.Gebruiker", b =>
                {
                    b.Property<int>("GebruikerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GebruikerId");

                    b.ToTable("Gebruikers");
                });

            modelBuilder.Entity("HogeschoolPXL.Data.Tables.Handboek", b =>
                {
                    b.Property<int>("HandboekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Afbeelding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("KostPrijs")
                        .HasColumnType("float");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UitgifteDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("HandboekId");

                    b.ToTable("Handboeken");
                });

            modelBuilder.Entity("HogeschoolPXL.Data.Tables.Inschrijving", b =>
                {
                    b.Property<int>("InschrijvingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcademieJaarId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("VakLectorId")
                        .HasColumnType("int");

                    b.HasKey("InschrijvingId");

                    b.HasIndex("AcademieJaarId");

                    b.HasIndex("StudentId");

                    b.HasIndex("VakLectorId");

                    b.ToTable("Inschrijvingen");
                });

            modelBuilder.Entity("HogeschoolPXL.Data.Tables.Lector", b =>
                {
                    b.Property<int>("LectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GebruikerId")
                        .HasColumnType("int");

                    b.HasKey("LectorId");

                    b.HasIndex("GebruikerId");

                    b.ToTable("Lectors");
                });

            modelBuilder.Entity("HogeschoolPXL.Data.Tables.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GebruikerId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("GebruikerId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("HogeschoolPXL.Data.Tables.Vak", b =>
                {
                    b.Property<int>("VakId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HandboekId")
                        .HasColumnType("int");

                    b.Property<double>("StudiePunten")
                        .HasColumnType("float");

                    b.Property<string>("VakNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VakId");

                    b.HasIndex("HandboekId");

                    b.ToTable("Vakken");
                });

            modelBuilder.Entity("HogeschoolPXL.Data.Tables.VakLector", b =>
                {
                    b.Property<int>("VakLectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LectorId")
                        .HasColumnType("int");

                    b.Property<int>("VakId")
                        .HasColumnType("int");

                    b.HasKey("VakLectorId");

                    b.HasIndex("LectorId");

                    b.HasIndex("VakId");

                    b.ToTable("VakLectors");
                });

            modelBuilder.Entity("HogeschoolPXL.Data.Tables.Inschrijving", b =>
                {
                    b.HasOne("HogeschoolPXL.Data.Tables.AcademieJaar", "AcademieJaar")
                        .WithMany("Inschrijvingen")
                        .HasForeignKey("AcademieJaarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HogeschoolPXL.Data.Tables.Student", "Student")
                        .WithMany("Inschrijvingen")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HogeschoolPXL.Data.Tables.VakLector", null)
                        .WithMany("Inschrijvingen")
                        .HasForeignKey("VakLectorId");
                });

            modelBuilder.Entity("HogeschoolPXL.Data.Tables.Lector", b =>
                {
                    b.HasOne("HogeschoolPXL.Data.Tables.Gebruiker", "Gebruiker")
                        .WithMany("Lectors")
                        .HasForeignKey("GebruikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HogeschoolPXL.Data.Tables.Student", b =>
                {
                    b.HasOne("HogeschoolPXL.Data.Tables.Gebruiker", "Gebruiker")
                        .WithMany("Students")
                        .HasForeignKey("GebruikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HogeschoolPXL.Data.Tables.Vak", b =>
                {
                    b.HasOne("HogeschoolPXL.Data.Tables.Handboek", "Handboek")
                        .WithMany("Vakken")
                        .HasForeignKey("HandboekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HogeschoolPXL.Data.Tables.VakLector", b =>
                {
                    b.HasOne("HogeschoolPXL.Data.Tables.Lector", "Lector")
                        .WithMany("VakLectors")
                        .HasForeignKey("LectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HogeschoolPXL.Data.Tables.Vak", "Vak")
                        .WithMany("VakLectors")
                        .HasForeignKey("VakId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
