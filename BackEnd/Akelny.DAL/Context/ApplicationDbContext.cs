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

            var restaurants = JsonSerializer.Deserialize<List<Restaurant>>(@"[
    {""Id"":1,""Title"":""Title1"",""Description"":""Description1"",""Speciality"":""Speciality1"",""Rating"":10.2},
    {""Id"":2,""Title"":""Title2"",""Description"":""Description2"",""Speciality"":""Speciality2"",""Rating"":10.2},
    {""Id"":3,""Title"":""Title3"",""Description"":""Description3"",""Speciality"":""Speciality3"",""Rating"":10.2}
]") ?? new List<Restaurant>();

            var sections = JsonSerializer.Deserialize<List<Section>>(@"[
    {""Id"":1,""Name"":""Breakfast""},
    {""Id"":2,""Name"":""Dinner""},
    {""Id"":3,""Name"":""Lunch""}
]") ?? new List<Section>();

            var meals = JsonSerializer.Deserialize<List<Meal>>(@"[
    {""Id"":1,""Name"":""Meal Name1"",""Description"":""Meal Des1"",""Price"":120.2,""RestaurantId"":1,""SectionId"":1},
    {""Id"":2,""Name"":""Meal Name2"",""Description"":""Meal Des2"",""Price"":120.2,""RestaurantId"":1,""SectionId"":2},
    {""Id"":3,""Name"":""Meal Name3"",""Description"":""Meal Des3"",""Price"":120.2,""RestaurantId"":1,""SectionId"":1}
]") ?? new List<Meal>();

            modelBuilder.Entity<Restaurant>().HasData(restaurants);
            modelBuilder.Entity<Section>().HasData(sections);
            modelBuilder.Entity<Meal>().HasData(meals);



        }
    }
}
