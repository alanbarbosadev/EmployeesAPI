﻿// <auto-generated />
using System;
using EmployeesAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeesAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221029142502_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeesAPI.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Deparment", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Marketing"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Accounting"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Finances"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Sales"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Human Resources"
                        });
                });

            modelBuilder.Entity("EmployeesAPI.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("numeric(18,2)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = 1,
                            Name = "Alan",
                            Salary = 1500m,
                            Surname = "Barbosa"
                        },
                        new
                        {
                            Id = 2,
                            Birthday = new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = 1,
                            Name = "Vanessa",
                            Salary = 1750m,
                            Surname = "Barbosa"
                        },
                        new
                        {
                            Id = 3,
                            Birthday = new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = 2,
                            Name = "Alex",
                            Salary = 2000m,
                            Surname = "Cavalcante"
                        },
                        new
                        {
                            Id = 4,
                            Birthday = new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = 2,
                            Name = "Uedemide",
                            Salary = 2250m,
                            Surname = "Lopes"
                        },
                        new
                        {
                            Id = 5,
                            Birthday = new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = 3,
                            Name = "Taylinne",
                            Salary = 2500m,
                            Surname = "Oliveira"
                        },
                        new
                        {
                            Id = 6,
                            Birthday = new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = 3,
                            Name = "Erivan",
                            Salary = 2750m,
                            Surname = "Cavalcante"
                        },
                        new
                        {
                            Id = 7,
                            Birthday = new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = 4,
                            Name = "Edvaldo",
                            Salary = 3000m,
                            Surname = "Barbosa"
                        },
                        new
                        {
                            Id = 8,
                            Birthday = new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = 4,
                            Name = "Eliza",
                            Salary = 3250m,
                            Surname = "Rabay"
                        },
                        new
                        {
                            Id = 9,
                            Birthday = new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = 5,
                            Name = "Edgar",
                            Salary = 3500m,
                            Surname = "Poe"
                        },
                        new
                        {
                            Id = 10,
                            Birthday = new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = 5,
                            Name = "Stephen",
                            Salary = 3750m,
                            Surname = "King"
                        });
                });

            modelBuilder.Entity("EmployeesAPI.Models.Employee", b =>
                {
                    b.HasOne("EmployeesAPI.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EmployeesAPI.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}