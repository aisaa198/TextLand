using System.Configuration;
using System.Data.Entity;
using TextLand.DAL.Models;

namespace TextLand.DAL.Data
{
    public class TextLandDbContext : DbContext
    {
        public TextLandDbContext() : base(GetConnectionString()) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payoff> Payoffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
               .HasRequired(o => o.AddingUser)
               .WithMany(u => u.AddedOrders)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
               .HasOptional(o => o.ExecutingUser)
               .WithMany(u => u.ExecutedOrders)
               .WillCascadeOnDelete(false);
        }

        private static string GetConnectionString() => ConfigurationManager.ConnectionStrings["TextLandDb"].ConnectionString;
    }
}
