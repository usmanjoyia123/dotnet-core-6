using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chapter21.TPH.Models;
using Chapter21.TPH.Models.Configurations;

namespace Chapter21.TPH
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; } // TPH Mapping
        public DbSet<Make> Makes { get; set; } 
        public DbSet<Radio> Radios { get; set; }  
        public DbSet<Driver> Drivers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //modelBuilder.Entity<Car>().ToTable("Cars"); TPT Mapping

            // Fluent API Data Annotations 
            new CarConfiguration().Configure(modelBuilder.Entity<Car>()); 
        }
    }
}
