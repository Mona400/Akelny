using Akelny.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Config
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            // Set table name
            builder.ToTable("Meals");

            // Set primary key
            builder.HasKey(m => m.Id);

            // Set property configurations
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Description).IsRequired();
            builder.Property(m => m.Price).IsRequired().HasColumnType("decimal(18, 2)");

            // Set foreign key relationships
            builder.HasOne(m => m.Restaurant)
                .WithMany(r => r.Meal)
                .HasForeignKey(m => m.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.Section)
                .WithMany(s => s.Meals)
                .HasForeignKey(m => m.SectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}