using flicket.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace flicket.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
    }
}
