﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TP1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250408094057_Seeds")]
    partial class Seeds
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ParticipantSession", b =>
                {
                    b.Property<int>("ParticipantsId")
                        .HasColumnType("integer");

                    b.Property<int>("SessionsId")
                        .HasColumnType("integer");

                    b.HasKey("ParticipantsId", "SessionsId");

                    b.HasIndex("SessionsId");

                    b.ToTable("ParticipantSession");
                });

            modelBuilder.Entity("TP1.Models.Evenement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("LieuId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LieuId");

                    b.ToTable("Evenements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Une conférence sur les dernières avancées en intelligence artificielle.",
                            LieuId = 1,
                            Name = "Conférence sur l'IA"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Un atelier pratique sur le développement web.",
                            LieuId = 2,
                            Name = "Atelier de développement web"
                        });
                });

            modelBuilder.Entity("TP1.Models.Lieu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Lieux");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adresse = "79 Rue de la République, 69002 Lyon",
                            Nom = "Pathé Bellcour"
                        },
                        new
                        {
                            Id = 2,
                            Adresse = "43 Rue des Docks, 69009 Lyon",
                            Nom = "Pathé Vaise"
                        });
                });

            modelBuilder.Entity("TP1.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telephone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Participants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jean@dupuis.fr",
                            Nom = "Dupuis",
                            Prenom = "Jean",
                            Telephone = "0606060606"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Jeanne@Dupont.fr",
                            Nom = "Dupont",
                            Prenom = "Jeanne",
                            Telephone = "0606060606"
                        });
                });

            modelBuilder.Entity("TP1.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EvenementId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("HeureDebut")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("HeureFin")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EvenementId");

                    b.ToTable("Sessions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EvenementId = 1,
                            HeureDebut = new DateTime(2025, 4, 8, 9, 0, 0, 0, DateTimeKind.Utc),
                            HeureFin = new DateTime(2025, 4, 8, 11, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            EvenementId = 2,
                            HeureDebut = new DateTime(2025, 4, 8, 12, 0, 0, 0, DateTimeKind.Utc),
                            HeureFin = new DateTime(2025, 4, 8, 14, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 3,
                            EvenementId = 1,
                            HeureDebut = new DateTime(2025, 4, 8, 15, 0, 0, 0, DateTimeKind.Utc),
                            HeureFin = new DateTime(2025, 4, 8, 17, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 4,
                            EvenementId = 2,
                            HeureDebut = new DateTime(2025, 4, 8, 18, 0, 0, 0, DateTimeKind.Utc),
                            HeureFin = new DateTime(2025, 4, 8, 20, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("ParticipantSession", b =>
                {
                    b.HasOne("TP1.Models.Participant", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP1.Models.Session", null)
                        .WithMany()
                        .HasForeignKey("SessionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TP1.Models.Evenement", b =>
                {
                    b.HasOne("TP1.Models.Lieu", "Lieu")
                        .WithMany("Evenements")
                        .HasForeignKey("LieuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lieu");
                });

            modelBuilder.Entity("TP1.Models.Session", b =>
                {
                    b.HasOne("TP1.Models.Evenement", "Evenement")
                        .WithMany("Sessions")
                        .HasForeignKey("EvenementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evenement");
                });

            modelBuilder.Entity("TP1.Models.Evenement", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("TP1.Models.Lieu", b =>
                {
                    b.Navigation("Evenements");
                });
#pragma warning restore 612, 618
        }
    }
}
