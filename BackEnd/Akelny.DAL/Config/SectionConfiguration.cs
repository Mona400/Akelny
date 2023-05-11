using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akelny.DAL.Models;

namespace Akelny.DAL.Config
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            // Set table name
            builder.ToTable("Sections");

            // Set primary key
            builder.HasKey(s => s.Id);

            // Set property configurations
            builder.Property(s => s.Name).IsRequired().HasMaxLength(50);

            // Set navigation property configurations
            builder.HasMany(s => s.Meals)
                   .WithOne(m => m.Section)
                   .HasForeignKey(m => m.SectionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
