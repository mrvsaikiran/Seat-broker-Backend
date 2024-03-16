using Microsoft.EntityFrameworkCore;
using Seat_broker_backend.Models;

namespace Seat_broker_backend.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        public DbSet<Movies> Movies { get; set; }

        public DbSet<Theatre> Theatre { get; set; }

        public DbSet<Shows> Shows { get; set; }

        public DbSet<Bookings> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Movies>().ToTable("Movies");
            modelBuilder.Entity<Shows>().ToTable("Shows");
            modelBuilder.Entity<Theatre>().ToTable("Theatre");
            modelBuilder.Entity<Bookings>().ToTable("Bookings");

        }
    }
}
