﻿using Akelny.DAL.Config;
using Akelny.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Akelny.DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Meal> Meals { get; set; }

        //public DbSet<TestUser> TestUsers { get; set; }

        public DbSet<Meals_Dates> Meals_and_Dates { get; set; }

        public DbSet<Subscriptions> Subscriptions { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
            modelBuilder.ApplyConfiguration(new MealConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new SubConfiguration());
            modelBuilder.ApplyConfiguration(new SubConfiguration());
            modelBuilder.Entity<User>().Property(c => c.DOB).HasColumnType("date");

            var restaurants = JsonSerializer.Deserialize<List<Restaurant>>(@"[
    {""Id"":1,""Title"":""Title1"",""Description"":""Description1"",""Speciality"":""Speciality1"",""Rating"":10.2 , ""Image"":""507a9056-bf91-4616-8036-f8443aaf41d7.jpg""},
    {""Id"":2,""Title"":""Title2"",""Description"":""Description2"",""Speciality"":""Speciality2"",""Rating"":10.2 , ""Image"":""507a9056-bf91-4616-8036-f8443aaf41d7.jpg""},
    {""Id"":3,""Title"":""Title3"",""Description"":""Description3"",""Speciality"":""Speciality3"",""Rating"":10.2 , ""Image"":""507a9056-bf91-4616-8036-f8443aaf41d7.jpg""}
]") ?? new List<Restaurant>();

            var sections = JsonSerializer.Deserialize<List<Section>>(@"[
    {""Id"":1,""Name"":""Breakfast""},
    {""Id"":2,""Name"":""Dinner""},
    {""Id"":3,""Name"":""Lunch""}
]") ?? new List<Section>();

            var meals = JsonSerializer.Deserialize<List<Meal>>(@"[
    {""Id"":1,""Image"":""test.png"" ,""Name"":""Meal Name1"",""Description"":""Meal Des1"",""Price"":120.2,""RestaurantId"":1,""SectionId"":1},
    {""Id"":2,""Image"":""test.png"" ,""Name"":""Meal Name2"",""Description"":""Meal Des2"",""Price"":120.2,""RestaurantId"":1,""SectionId"":2},
    {""Id"":3,""Image"":""test.png"" ,""Name"":""Meal Name3"",""Description"":""Meal Des3"",""Price"":120.2,""RestaurantId"":1,""SectionId"":1}
]") ?? new List<Meal>();

            var Promotion =
                new Promotion
                {
                    Id = 1,
                    date = new DateTime(2023, 08, 11),
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    ImageUrl = "test_sand.jpg",
                    PriceAfter = 200.99m,
                    PriceBefore = 259.99m,
                    Title = "Burger Sandwich"


                };
            





            //var Meals_dates = new List<Meals_Dates>
            //{
            //    new Meals_Dates
            //    {
            //        ID= 1,
            //        Date= DateTime.Now,
            //        MealID= 1,
            //        SubscriptionsID= 1,

            //    }
            //};

            //var subscriptions = new List<Subscriptions>
            //{
            //    new Subscriptions{Id=1,Monthly_Price=59.99m ,RenewDate=new DateTime(),
            //    TestUserID="1590d5a7-ca58-42d4-bdff-6eebf044edcc",
            //    Substate = Substate.Pending,
            //    TimeCreated=new DateTime()
            //    }
            //};
               modelBuilder.Entity<Promotion>().HasData(Promotion);
            modelBuilder.Entity<Restaurant>().HasData(restaurants);
            modelBuilder.Entity<Section>().HasData(sections);
            modelBuilder.Entity<Meal>().HasData(meals);
          //  modelBuilder.Entity<Subscriptions>().HasData(subscriptions);
           // modelBuilder.Entity<Meals_Dates>().HasData(Meals_dates);





        }
    }
}
