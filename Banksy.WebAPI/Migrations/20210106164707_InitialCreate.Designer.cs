﻿// <auto-generated />
using System;
using Banksy.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Banksy.WebAPI.Migrations
{
    [DbContext(typeof(BanksyContext))]
    [Migration("20210106164707_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Banksy.WebAPI.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Housing"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Transportation"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Groceries"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Utilities"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Insurance"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Medical and Healthcare"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Saving, Investing and Debt payments"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Personal spending"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Recreation and Entertainment"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Miscellaneous"
                        });
                });

            modelBuilder.Entity("Banksy.WebAPI.Models.Mutation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContraAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DebitCredit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MutationType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Mutations");
                });

            modelBuilder.Entity("Banksy.WebAPI.Models.Category", b =>
                {
                    b.HasOne("Banksy.WebAPI.Models.Category", null)
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Banksy.WebAPI.Models.Mutation", b =>
                {
                    b.HasOne("Banksy.WebAPI.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Banksy.WebAPI.Models.Category", b =>
                {
                    b.Navigation("SubCategories");
                });
#pragma warning restore 612, 618
        }
    }
}