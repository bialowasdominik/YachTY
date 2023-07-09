using Microsoft.EntityFrameworkCore;
using Yachts.Models;

namespace Yachts.Utils
{
    public class YachtsDbContext : DbContext
    {
        private string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=YachtsDb;Trusted_Connection=True;";

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Yacht> Yachts { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Opinion> Opinions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Yacht>()
                .Property(e => e.PricePerDay)
                .HasColumnType("decimal(18,4)");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
