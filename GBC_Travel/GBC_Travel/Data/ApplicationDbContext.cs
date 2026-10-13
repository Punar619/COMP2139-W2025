using Microsoft.EntityFrameworkCore;
using GBC_Travel.Models;

namespace GBC_Travel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}