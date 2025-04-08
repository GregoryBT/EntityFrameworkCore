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
            modelBuilder.Entity<Evenement>()
                .HasOne(e => e.Lieu)
                .WithMany(l => l.Evenements)
                .HasForeignKey(e => e.LieuId);

            modelBuilder.Entity<Participant>()
                .HasMany(p => p.Sessions)
                .WithMany(s => s.Participants)
                .UsingEntity(j => j.ToTable("ParticipantSession"));

            modelBuilder.Entity<Session>()
                .HasOne(s => s.Evenement)
                .WithMany(e => e.Sessions)
                .HasForeignKey(s => s.EvenementId);
        }
    }

}

