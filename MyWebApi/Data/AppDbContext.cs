using MyWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet pour la table "Products"
        public DbSet<Product>? Products { get; set; }
        // DbSet pour la table "Categories"
        public DbSet<Category>? Categories { get; set; }
        // DbSet pour la table "Customers"
        public DbSet<Customer>? Customers { get; set; }
        // DbSet pour la table "Orders"
        public DbSet<Order>? Orders { get; set; }
        // DbSet pour la table "OrderItems"
        public DbSet<OrderItem>? OrderItems { get; set; }
        // DbSet pour la table "Addresses"
        public DbSet<Address>? Addresses { get; set; }
        // DbSet pour la table "PriceHistory"
        public DbSet<PriceHistory>? PriceHistories { get; set; }
        // DbSet pour la table "ProductReviews"
        public DbSet<ProductReview>? ProductReviews { get; set; }
        // DbSet pour la table "Stock"
        public DbSet<Stock>? Stocks { get; set; }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);

                // Relation avec Orders
                entity.HasMany(c => c.Orders)
                      .WithOne(o => o.Customer)
                      .HasForeignKey(o => o.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relation avec ProductReviews
                entity.HasMany(c => c.ProductReviews)
                      .WithOne(r => r.Customer)
                      .HasForeignKey(r => r.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relation avec addresses
                entity.OwnsOne(c => c.ShippingAddress, sa =>
                {
                    sa.WithOwner();
                    sa.Property(a => a.Street).IsRequired().HasMaxLength(100);
                    sa.Property(a => a.City).IsRequired().HasMaxLength(50);
                    sa.Property(a => a.ZipCode).IsRequired().HasMaxLength(10);
                });
                // Relation avec addresses
                entity.OwnsOne(c => c.BillingAddress, ba =>
                {
                    ba.WithOwner();
                    ba.Property(a => a.Street).IsRequired().HasMaxLength(100);
                    ba.Property(a => a.City).IsRequired().HasMaxLength(50);
                    ba.Property(a => a.ZipCode).IsRequired().HasMaxLength(10);
                });
            });

            // Configuration Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);

                // Contrainte d'unicité sur le nom de la catégorie
                entity.HasIndex(e => e.Name).IsUnique();

                // Relation avec les sous-catégories
                entity.HasMany(c => c.SubCategories)
                      .WithOne(c => c.ParentCategory)
                      .HasForeignKey(c => c.ParentCategoryId)
                      .OnDelete(DeleteBehavior.Restrict); // Pour éviter la suppression en cascade

                // Relation avec les produits
                entity.HasMany(c => c.Products)
                      .WithOne(p => p.Category)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            // Configuration Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Price).HasPrecision(18, 2);

                // Contrainte de vérification pour le prix
                entity.ToTable(t => t.HasCheckConstraint("CK_Product_Price", "`Price` > 0"));

                // Index sur le nom pour la recherche rapide
                entity.HasIndex(e => e.Name);

                // Relations
                entity.HasMany(p => p.PriceHistory)
                      .WithOne(h => h.Product)
                      .HasForeignKey(h => h.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(p => p.Reviews)
                      .WithOne(r => r.Product)
                      .HasForeignKey(r => r.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);
            })

            // Configuration Order


            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OrderNumber).IsRequired().HasMaxLength(20);
                entity.Property(e => e.TotalAmount).HasPrecision(18, 2);

                // Index sur le numéro de commande
                entity.HasIndex(e => e.OrderNumber).IsUnique();

                // Index composite sur CustomerId et OrderDate pour les recherches
                entity.HasIndex(e => new { e.CustomerId, e.OrderDate });

                // Configuration de l'adresse de livraison comme owned entity
                entity.OwnsOne(o => o.ShippingAddress);

                entity.HasOne(o => o.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(o => o.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(o => o.OrderItems)
                    .WithOne(oi => oi.Order)
                    .HasForeignKey(oi => oi.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuration OrderItem
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
                entity.Property(e => e.TotalPrice).HasPrecision(18, 2);
                entity.Property(e => e.DiscountAmount).HasPrecision(18, 2);

                // Contrainte de vérification pour la quantité
                entity.ToTable(t => t.HasCheckConstraint("CK_OrderItem_Quantity", "`Quantity` > 0"));

                entity.HasOne(oi => oi.Order)
                    .WithMany(o => o.OrderItems)
                    .HasForeignKey(oi => oi.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(oi => oi.Product)
                    .WithMany()
                    .HasForeignKey(oi => oi.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuration ProductReview
            modelBuilder.Entity<ProductReview>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Rating).IsRequired();

                // Contrainte de vérification pour le rating
                entity.ToTable(t => t.HasCheckConstraint("CK_ProductReview_Rating", "`Rating` BETWEEN 1 AND 5"));

                // Index composite pour éviter les doublons de reviews
                entity.HasIndex(e => new { e.ProductId, e.CustomerId }).IsUnique();

                entity.HasOne(pr => pr.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(pr => pr.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pr => pr.Customer)
                    .WithMany(c => c.Reviews)
                    .HasForeignKey(pr => pr.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuration PriceHistory
            modelBuilder.Entity<PriceHistory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OldPrice).HasPrecision(18, 2);
                entity.Property(e => e.NewPrice).HasPrecision(18, 2);

                // Index sur la date de changement pour les recherches chronologiques
                entity.HasIndex(e => e.ChangeDate);

                entity.HasOne(ph => ph.Product)
                    .WithMany(p => p.PriceHistories)
                    .HasForeignKey(ph => ph.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

