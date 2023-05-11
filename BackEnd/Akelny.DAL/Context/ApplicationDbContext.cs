using Akelny.DAL.Config;
using Akelny.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Akelny.DAL.Context
{
    public class ApplicationDbContext:DbContext
    {
         public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Section> Sections { get; set; }    
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Meal> Meals { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
            modelBuilder.ApplyConfiguration(new MealConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());

            var resturant = JsonSerializer.Deserialize<List<Restaurant>>("""[{"Id":1,"Title":"Title1","Description":"Description1","Speciality":"Speciality1","Rating":10.2}]""") ?? new();
            var meal = JsonSerializer.Deserialize<List<Meal>>("""[{"Id":1,"Name":"Meal Name1","Description":"Meal Des1","Price":120.2,"RestaurantId":1,"SectionId":4}]""") ?? new();
            modelBuilder.Entity<Restaurant>().HasData(resturant);
            modelBuilder.Entity<Meal>().HasData(meal);
        

            
        }
    }
}
