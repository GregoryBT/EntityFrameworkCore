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

    }
}