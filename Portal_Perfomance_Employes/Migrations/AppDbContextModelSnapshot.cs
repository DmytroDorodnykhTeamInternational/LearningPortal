﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortalPerfomanceEmployees.Data;

#nullable disable

namespace PortalPerfomanceEmployees.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Seniority")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 9, 4, 21, 38, 14, 243, DateTimeKind.Local).AddTicks(4825),
                            DateOfBirth = new DateTime(2000, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "emp@email.com",
                            FirstName = "Emp1",
                            LastName = "Test1",
                            Password = "1234",
                            Role = 0,
                            Seniority = 0,
                            Username = "emp"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2022, 9, 4, 21, 38, 14, 243, DateTimeKind.Local).AddTicks(4869),
                            DateOfBirth = new DateTime(1980, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "teamlead@email.com",
                            FirstName = "Emp2",
                            LastName = "Test2",
                            Password = "1234",
                            Role = 1,
                            Seniority = 1,
                            Username = "teamlead"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2022, 9, 4, 21, 38, 14, 243, DateTimeKind.Local).AddTicks(4873),
                            DateOfBirth = new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "admin@email.com",
                            FirstName = "Emp3",
                            LastName = "Test3",
                            Password = "1234",
                            Role = 2,
                            Seniority = 2,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TeamLeaderId")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = 1,
                            DateCreated = new DateTime(2022, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TeamLeaderId = 2,
                            TeamName = "Team number one"
                        });
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.TeamMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TeamMembers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 1,
                            FirstName = "Emp1",
                            FromDate = new DateTime(2022, 9, 4, 21, 38, 14, 243, DateTimeKind.Local).AddTicks(4956),
                            IsActive = true,
                            LastName = "Test1",
                            TeamId = 1
                        },
                        new
                        {
                            Id = 2,
                            EmployeeId = 2,
                            FirstName = "Emp2",
                            FromDate = new DateTime(2022, 9, 4, 21, 38, 14, 243, DateTimeKind.Local).AddTicks(4962),
                            IsActive = true,
                            LastName = "Test2",
                            TeamId = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
