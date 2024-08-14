using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VidlyMoshNet8.Models;

namespace VidlyMoshNet8.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var adminRoleId = "799ed1f5-dc54-4459-b9cf-cbc4e74419f4";
            var userRoleId = "2ff420db-dae7-41f9-8d1c-24c6d9651056";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin", 
                    NormalizedName = "ADMIN", 
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId

                },
                new IdentityRole
                {
                    Name = "User", 
                    NormalizedName = "USER",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
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
