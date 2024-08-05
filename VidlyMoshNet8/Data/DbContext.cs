using Microsoft.EntityFrameworkCore;
using VidlyMoshNet8.Models;

namespace VidlyMoshNet8.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customers> Customers { get; set; }
    }
}
