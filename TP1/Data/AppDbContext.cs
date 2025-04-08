using TP1.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Evenement> Evenements { get; set; } = null!;
        public DbSet<Lieu> Lieux { get; set; } = null!;
        public DbSet<Participant> Participants { get; set; } = null!;
        public DbSet<Session> Sessions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relations
            modelBuilder.Entity<Evenement>()
                .HasOne(e => e.Lieu)
                .WithMany(l => l.Evenements)
                .HasForeignKey(e => e.LieuId);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.Evenement)
                .WithMany(e => e.Sessions)
                .HasForeignKey(s => s.EvenementId);

            modelBuilder.Entity<Participant>()
                .HasMany(p => p.Sessions)
                .WithMany(s => s.Participants)
                .UsingEntity<Dictionary<string, object>>(
                    "ParticipantSession",
                    j => j.HasData(
                        new { ParticipantsId = 1, SessionsId = 1 },
                        new { ParticipantsId = 1, SessionsId = 3 },
                        new { ParticipantsId = 2, SessionsId = 2 },
                        new { ParticipantsId = 2, SessionsId = 4 }
                    )
                );

            // Seed data
            modelBuilder.Entity<Lieu>().HasData(
                new Lieu { Id = 1, Nom = "Pathé Bellcour", Adresse = "79 Rue de la République, 69002 Lyon" },
                new Lieu { Id = 2, Nom = "Pathé Vaise", Adresse = "43 Rue des Docks, 69009 Lyon" }
            );
            modelBuilder.Entity<Evenement>().HasData(
                new Evenement { Id = 1, Name = "Conférence sur l'IA", Description = "Une conférence sur les dernières avancées en intelligence artificielle.", LieuId = 1 },
                new Evenement { Id = 2, Name = "Atelier de développement web", Description = "Un atelier pratique sur le développement web.", LieuId = 2 }
            );
            modelBuilder.Entity<Session>().HasData(
                new Session
                {
                    Id = 1,
                    HeureDebut = DateTime.SpecifyKind(new DateTime(2025, 04, 08, 9, 0, 0), DateTimeKind.Utc),
                    HeureFin = DateTime.SpecifyKind(new DateTime(2025, 04, 08, 11, 0, 0), DateTimeKind.Utc),
                    EvenementId = 1
                },
                new Session
                {
                    Id = 2,
                    HeureDebut = DateTime.SpecifyKind(new DateTime(2025, 04, 08, 12, 0, 0), DateTimeKind.Utc),
                    HeureFin = DateTime.SpecifyKind(new DateTime(2025, 04, 08, 14, 0, 0), DateTimeKind.Utc),
                    EvenementId = 2
                },
                new Session
                {
                    Id = 3,
                    HeureDebut = DateTime.SpecifyKind(new DateTime(2025, 04, 08, 15, 0, 0), DateTimeKind.Utc),
                    HeureFin = DateTime.SpecifyKind(new DateTime(2025, 04, 08, 17, 0, 0), DateTimeKind.Utc),
                    EvenementId = 1
                },
                new Session
                {
                    Id = 4,
                    HeureDebut = DateTime.SpecifyKind(new DateTime(2025, 04, 08, 18, 0, 0), DateTimeKind.Utc),
                    HeureFin = DateTime.SpecifyKind(new DateTime(2025, 04, 08, 20, 0, 0), DateTimeKind.Utc),
                    EvenementId = 2
                }
            );
            modelBuilder.Entity<Participant>()
                .HasData(
                    new Participant { Id = 1, Nom = "Dupuis", Prenom = "Jean", Email = "jean@dupuis.fr", Telephone = "0606060606" },
                    new Participant { Id = 2, Nom = "Dupont", Prenom = "Jeanne", Email = "Jeanne@Dupont.fr", Telephone = "0606060606" }
                );
        }
    }
}