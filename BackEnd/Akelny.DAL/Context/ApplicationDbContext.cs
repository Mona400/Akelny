using Akelny.DAL.Config;
using Akelny.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Akelny.DAL.Context
{
    public class ApplicationDbContext:IdentityDbContext
    {
        
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Section> Sections { get; set; }    
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Meal> Meals { get; set; }

        public DbSet<TestUser> TestUsers { get; set; }

        public DbSet<Meals_Dates> Meals_and_Dates { get; set; }

        public DbSet<Subscriptions> Subscriptions { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

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

            var TestUser = new List<TestUser>
            {
                new TestUser{Id=1 , Username="mahmoud1"},
                new TestUser{Id=2 , Username="mahmoud2"},
                new TestUser{Id=3 , Username="mahmoud3"},
            };


            var Meals_dates = new List<Meals_Dates>
            {
                new Meals_Dates
                {
                    ID= 1,
                    Date= "15:00 AM",
                    MealID= 1,
                    SubscriptionsID= 1,

                }
            };

            var subscriptions = new List<Subscriptions>
            {
                new Subscriptions{Id=1,Monthly_Price=59.99m ,RenewDate=new DateTime(),
                TestUserID=1,
                Substate = Substate.Pending,
                TimeCreated=new DateTime()
                }
            };

            modelBuilder.Entity<Restaurant>().HasData(restaurants);
            modelBuilder.Entity<Section>().HasData(sections);
            modelBuilder.Entity<Meal>().HasData(meals);
            modelBuilder.Entity<TestUser>().HasData(TestUser);
            modelBuilder.Entity<Subscriptions>().HasData(subscriptions);
            modelBuilder.Entity<Meals_Dates>().HasData(Meals_dates);





        }
    }
}
