﻿// <auto-generated />
using System;
using FinanceApp.API.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinanceApp.API.Migrations
{
    [DbContext(typeof(FinanceAppDbContext))]
    [Migration("20240127111044_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinanceApp.API.Domain.Entities.Account", b =>
                {
                    b.Property<Guid>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UUID");

                    b.HasIndex("CustomerId");

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            UUID = new Guid("5d645d64-2ada-4747-a94a-fa46ee656741"),
                            Alias = "Normal Account",
                            Currency = "TRY",
                            CustomerId = new Guid("87d39d2f-4b9c-470f-a47f-9f0e3f4c38da")
                        },
                        new
                        {
                            UUID = new Guid("5e8b85f3-62dd-4960-a63d-0299f2524e83"),
                            Alias = "USD Account",
                            Currency = "USD",
                            CustomerId = new Guid("87d39d2f-4b9c-470f-a47f-9f0e3f4c38da")
                        });
                });

            modelBuilder.Entity("FinanceApp.API.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UUID");

                    b.HasIndex("IdNumber")
                        .IsUnique();

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            UUID = new Guid("87d39d2f-4b9c-470f-a47f-9f0e3f4c38da"),
                            IdNumber = "12345678901",
                            Name = "Yasin",
                            Surname = "Coskun"
                        });
                });

            modelBuilder.Entity("FinanceApp.API.Domain.Entities.Account", b =>
                {
                    b.HasOne("FinanceApp.API.Domain.Entities.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("FinanceApp.API.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}