using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter21.TPH.Models.Configurations
{
    public class CarConfiguration:IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder) {
            builder.ToTable("Inventory", "dbo");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("InventoryId");
            
        }
    }
}
