﻿// <auto-generated />
using System;
using Akelny.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Akelny.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230514134450_Resturant")]
    partial class Resturant
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Akelny.DAL.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("SectionId");

                    b.ToTable("Meals", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Meal Des1",
                            Image = "",
                            Name = "Meal Name1",
                            Price = 120.2m,
                            RestaurantId = 1,
                            SectionId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Meal Des2",
                            Image = "",
                            Name = "Meal Name2",
                            Price = 120.2m,
                            RestaurantId = 1,
                            SectionId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Meal Des3",
                            Image = "",
                            Name = "Meal Name3",
                            Price = 120.2m,
                            RestaurantId = 1,
                            SectionId = 1
                        });
                });

            modelBuilder.Entity("Akelny.DAL.Models.Meals_Dates", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MealID")
                        .HasColumnType("int")
                        .HasColumnName("Meal_ID");

                    b.Property<int>("SubscriptionsID")
                        .HasColumnType("int")
                        .HasColumnName("Sub_ID");

                    b.HasKey("ID");

                    b.HasIndex("MealID");

                    b.HasIndex("SubscriptionsID");

                    b.ToTable("Meals_and_Dates");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Date = "15:00 AM",
                            MealID = 1,
                            SubscriptionsID = 1
                        });
                });

            modelBuilder.Entity("Akelny.DAL.Models.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Minutes")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceAfter")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal>("PriceBefore")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("Seconds")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("days")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("Akelny.DAL.Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Rating")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Speciality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Restaurant");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description1",
                            Image = "",
                            Rating = 10.2m,
                            Speciality = "Speciality1",
                            Title = "Title1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description2",
                            Image = "",
                            Rating = 10.2m,
                            Speciality = "Speciality2",
                            Title = "Title2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Description3",
                            Image = "",
                            Rating = 10.2m,
                            Speciality = "Speciality3",
                            Title = "Title3"
                        });
                });

            modelBuilder.Entity("Akelny.DAL.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Sections", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Breakfast"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dinner"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Lunch"
                        });
                });

            modelBuilder.Entity("Akelny.DAL.Models.Subscriptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Monthly_Price")
                        .HasColumnType("decimal(9,2)");

                    b.Property<DateTime>("RenewDate")
                        .HasColumnType("datetime2(0)");

                    b.Property<int>("Substate")
                        .HasColumnType("int");

                    b.Property<int>("TestUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime2(0)");

                    b.HasKey("Id");

                    b.HasIndex("TestUserID");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Monthly_Price = 59.99m,
                            RenewDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Substate = 0,
                            TestUserID = 1,
                            TimeCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Akelny.DAL.Models.TestUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TestUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Username = "mahmoud1"
                        },
                        new
                        {
                            Id = 2,
                            Username = "mahmoud2"
                        },
                        new
                        {
                            Id = 3,
                            Username = "mahmoud3"
                        });
                });

            modelBuilder.Entity("RestaurantSection", b =>
                {
                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("SectionsId")
                        .HasColumnType("int");

                    b.HasKey("RestaurantId", "SectionsId");

                    b.HasIndex("SectionsId");

                    b.ToTable("RestaurantSection");
                });

            modelBuilder.Entity("Akelny.DAL.Models.Meal", b =>
                {
                    b.HasOne("Akelny.DAL.Models.Restaurant", "Restaurant")
                        .WithMany("Meals")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Akelny.DAL.Models.Section", "Section")
                        .WithMany("Meals")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("Akelny.DAL.Models.Meals_Dates", b =>
                {
                    b.HasOne("Akelny.DAL.Models.Meal", "meal")
                        .WithMany()
                        .HasForeignKey("MealID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Akelny.DAL.Models.Subscriptions", "Subscriptions")
                        .WithMany("Meals_Dates")
                        .HasForeignKey("SubscriptionsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscriptions");

                    b.Navigation("meal");
                });

            modelBuilder.Entity("Akelny.DAL.Models.Subscriptions", b =>
                {
                    b.HasOne("Akelny.DAL.Models.TestUser", "user")
                        .WithMany()
                        .HasForeignKey("TestUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("RestaurantSection", b =>
                {
                    b.HasOne("Akelny.DAL.Models.Restaurant", null)
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Akelny.DAL.Models.Section", null)
                        .WithMany()
                        .HasForeignKey("SectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Akelny.DAL.Models.Restaurant", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("Akelny.DAL.Models.Section", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("Akelny.DAL.Models.Subscriptions", b =>
                {
                    b.Navigation("Meals_Dates");
                });
#pragma warning restore 612, 618
        }
    }
}
