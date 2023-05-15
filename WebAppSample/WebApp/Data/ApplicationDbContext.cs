using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Models.Configurations;

namespace WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; } // TPH Mapping
        public DbSet<Make> Makes { get; set; }
        public DbSet<Radio> Radios { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Car>().ToTable("Cars"); //TPT Mapping

            // Fluent API Data Annotations 
            new CarConfiguration().Configure(modelBuilder.Entity<Car>());
        }
    }
}
