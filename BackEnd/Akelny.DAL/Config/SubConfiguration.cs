using Akelny.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Config
{
    public class SubConfiguration : IEntityTypeConfiguration<Subscriptions>
    {
        public void Configure(EntityTypeBuilder<Subscriptions> builder)
        {
            builder.HasOne(c => c.user).WithMany(us => us.subscriptions).HasForeignKey(en => en.TestUserID).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Meals_Dates).WithOne(me => me.Subscriptions).HasForeignKey(en => en.SubscriptionsID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
