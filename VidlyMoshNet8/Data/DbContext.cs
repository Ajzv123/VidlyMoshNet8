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
        public DbSet<MembershipType> MembershipType { get; set; }
        public DbSet<Genre> Genre { get; set; }
    }
}
/*
 *  AppDbContext es la clase que define el contexto de la base de datos para tu aplicación. Proporciona acceso a las tablas Movies y Customers
 * y se configura mediante inyección de dependencias en el constructor. Esta clase es fundamental para interactuar con la base de datos utilizando Entity Framework Core.

 *  
 */
