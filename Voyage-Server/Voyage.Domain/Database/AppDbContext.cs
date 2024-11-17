using Microsoft.EntityFrameworkCore;
using Voyage.Domain.Models;

namespace Voyage.Domain.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<AvailableTicket> AvailableTickets { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Adil\\SQLEXPRESS;Database=Voyage;Trusted_Connection=True;TrustServerCertificate=true;");
        }
    }
}
