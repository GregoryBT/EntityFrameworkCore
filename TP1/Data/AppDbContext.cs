using TP1.Models;
using Microsoft.EntityFrameworkCore;

namespace TP1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Evenement> Evenements { get; set; } = null!;
        public DbSet<EvenementParticipant> EvenementParticipants { get; set; } = null!;
        public DbSet<Intervenant> Intervenants { get; set; } = null!;
        public DbSet<Lieu> Lieux { get; set; } = null!;
        public DbSet<Notation> Notations { get; set; } = null!;
        public DbSet<Participant> Participants { get; set; } = null!;
        public DbSet<Salle> Salles { get; set; } = null!;
        public DbSet<Session> Sessions { get; set; } = null!;
        public DbSet<SessionIntervenant> SessionIntervenants { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relations avec Notation
            modelBuilder.Entity<Notation>()
                .HasOne(n => n.Session)
                .WithMany(s => s.Notations)
                .HasForeignKey(n => n.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Notation>()
                .HasOne(n => n.Participant)
                .WithMany(p => p.Notations)
                .HasForeignKey(n => n.ParticipantId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relations avec EvenementParticipant
            modelBuilder.Entity<EvenementParticipant>()
                .HasKey(ep => new { ep.EvenementId, ep.ParticipantId });

            modelBuilder.Entity<EvenementParticipant>()
                .HasOne(ep => ep.Evenement)
                .WithMany(e => e.EvenementParticipants)
                .HasForeignKey(ep => ep.EvenementId);

            modelBuilder.Entity<EvenementParticipant>()
                .HasOne(ep => ep.Participant)
                .WithMany(p => p.EvenementParticipants)
                .HasForeignKey(ep => ep.ParticipantId);

            // Relations avec SessionIntervenant
            modelBuilder.Entity<SessionIntervenant>()
                .HasKey(si => new { si.SessionId, si.IntervenantId });

            modelBuilder.Entity<SessionIntervenant>()
                .HasOne(si => si.Session)
                .WithMany(s => s.SessionIntervenants)
                .HasForeignKey(si => si.SessionId);

            modelBuilder.Entity<SessionIntervenant>()
                .HasOne(si => si.Intervenant)
                .WithMany(i => i.SessionIntervenants)
                .HasForeignKey(si => si.IntervenantId);

            // Relations avec Evenement
            modelBuilder.Entity<Evenement>()
                .HasOne(e => e.Lieu)
                .WithMany(l => l.Evenements)
                .HasForeignKey(e => e.LieuId);

            // Relations avec Session
            modelBuilder.Entity<Session>()
                .HasOne(s => s.Evenement)
                .WithMany(e => e.Sessions)
                .HasForeignKey(s => s.EvenementId);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.Salle)
                .WithMany(salle => salle.Sessions)
                .HasForeignKey(s => s.SalleId);

            // Relations avec Salle
            modelBuilder.Entity<Salle>()
                .HasOne(s => s.Lieu)
                .WithMany(l => l.Salles)
                .HasForeignKey(s => s.LieuId);


            // Seed data
            // Lieu
            modelBuilder.Entity<Lieu>().HasData(
                new Lieu { Id = 1, Nom = "Centre des Congrès", Adresse = "123 Rue Principale", Ville = "Lyon", Pays = "France", Capacite = 500 },
                new Lieu { Id = 2, Nom = "Palais des Expos", Adresse = "456 Rue Expo", Ville = "Paris", Pays = "France", Capacite = 800 },
                new Lieu { Id = 3, Nom = "Auditorium Sud", Adresse = "789 Rue Sud", Ville = "Marseille", Pays = "France", Capacite = 300 }
            );

            // Salle
            modelBuilder.Entity<Salle>().HasData(
                new Salle { Id = 1, Nom = "Salle A", Capacite = 100, LieuId = 1 },
                new Salle { Id = 2, Nom = "Salle B", Capacite = 150, LieuId = 1 },
                new Salle { Id = 3, Nom = "Salle C", Capacite = 200, LieuId = 2 }
            );

            // Evenement
            modelBuilder.Entity<Evenement>().HasData(
                new Evenement { Id = 1, Titre = "Tech 2025", Description = "Conférence tech.", DateDebut = "2025-09-04", DateFin = "2025-09-04", Statut = "Ouvert", Categorie = "Tech", LieuId = 1 },
                new Evenement { Id = 2, Titre = "IA Summit", Description = "Sommet sur l'IA.", DateDebut = "2025-09-04", DateFin = "2025-09-04", Statut = "Complet", Categorie = "IA", LieuId = 2 },
                new Evenement { Id = 3, Titre = "Web3 Days", Description = "Événement blockchain.", DateDebut = "2025-09-04", DateFin = "2025-09-04", Statut = "Ouvert", Categorie = "Blockchain", LieuId = 3 }
            );

            // Participant
            modelBuilder.Entity<Participant>().HasData(
                new Participant { Id = 1, Prenom = "Alice", Nom = "Durand", Email = "alice@exemple.com", Entreprise = "TechCorp", Poste = "Dév" },
                new Participant { Id = 2, Prenom = "Bob", Nom = "Martin", Email = "bob@exemple.com", Entreprise = "DataInc", Poste = "Analyste" },
                new Participant { Id = 3, Prenom = "Claire", Nom = "Morel", Email = "claire@exemple.com", Entreprise = "WebSolutions", Poste = "Cheffe de projet" }
            );

            // EvenementParticipant
            modelBuilder.Entity<EvenementParticipant>().HasData(
                new EvenementParticipant { EvenementId = 1, ParticipantId = 1, DateInscription = "2025-09-04", StatutPresence = "Présente" },
                new EvenementParticipant { EvenementId = 1, ParticipantId = 2, DateInscription = "2025-09-04", StatutPresence = "Présent" },
                new EvenementParticipant { EvenementId = 2, ParticipantId = 3, DateInscription = "2025-09-04", StatutPresence = "Présente" }
            );

            // Session
            modelBuilder.Entity<Session>().HasData(
                new Session { Id = 1, Titre = "Intro IA", Description = "Bases de l'IA", HeureDebut = "2025-09-04", HeureFin = "2025-09-04", EvenementId = 1, SalleId = 1 },
                new Session { Id = 2, Titre = "Blockchain", Description = "Fonctionnement", HeureDebut = "2025-09-04", HeureFin = "2025-09-04", EvenementId = 3, SalleId = 3 },
                new Session { Id = 3, Titre = "Cloud Azure", Description = "Déploiement", HeureDebut = "2025-09-04", HeureFin = "2025-09-04", EvenementId = 2, SalleId = 2 }
            );

            // Notation
            modelBuilder.Entity<Notation>().HasData(
                new Notation { Id = 1, SessionId = 1, ParticipantId = 1, Note = 5, Commentaire = "Super présentation" },
                new Notation { Id = 2, SessionId = 2, ParticipantId = 2, Note = 4, Commentaire = "Très intéressant" },
                new Notation { Id = 3, SessionId = 3, ParticipantId = 3, Note = 5, Commentaire = "Excellent contenu" }
            );
        }
    }
}