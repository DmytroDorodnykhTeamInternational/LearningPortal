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

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.Certification", b =>
                {
                    b.Property<int>("CertificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CertificationId"), 1L, 1);

                    b.Property<string>("CertificationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("CertificationId");

                    b.HasIndex("SkillId")
                        .IsUnique();

                    b.ToTable("Certification");
                });

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
                            Created = new DateTime(2022, 9, 9, 1, 22, 7, 94, DateTimeKind.Local).AddTicks(2361),
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
                            Created = new DateTime(2022, 9, 9, 1, 22, 7, 94, DateTimeKind.Local).AddTicks(2395),
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
                            Created = new DateTime(2022, 9, 9, 1, 22, 7, 94, DateTimeKind.Local).AddTicks(2398),
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

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.EmployeeCertification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CertifcateUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CertificationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCertified")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CertificationId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeCertification");
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.EmployeeSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<int>("SkillLevelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SkillId");

                    b.HasIndex("SkillLevelId");

                    b.ToTable("EmployeeSkill");
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillId"), 1L, 1);

                    b.Property<int>("SkillLevelTypeId")
                        .HasColumnType("int");

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkillTypeId")
                        .HasColumnType("int");

                    b.HasKey("SkillId");

                    b.HasIndex("SkillLevelTypeId");

                    b.HasIndex("SkillTypeId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.SkillLevel", b =>
                {
                    b.Property<int>("SkillLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillLevelId"), 1L, 1);

                    b.Property<string>("SkillLevelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkillLevelTypeId")
                        .HasColumnType("int");

                    b.HasKey("SkillLevelId");

                    b.HasIndex("SkillLevelTypeId");

                    b.ToTable("SkillLevel");
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.SkillLevelType", b =>
                {
                    b.Property<int>("SkillLevelTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillLevelTypeId"), 1L, 1);

                    b.Property<string>("SkillLevelTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillLevelTypeId");

                    b.ToTable("SkillLevelType");
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.SkillType", b =>
                {
                    b.Property<int>("SkillTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillTypeId"), 1L, 1);

                    b.Property<string>("SkillTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillTypeId");

                    b.ToTable("SkillType");
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

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamMembers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 1,
                            FirstName = "Emp1",
                            FromDate = new DateTime(2022, 9, 9, 1, 22, 7, 94, DateTimeKind.Local).AddTicks(2410),
                            IsActive = true,
                            LastName = "Test1",
                            TeamId = 1
                        },
                        new
                        {
                            Id = 2,
                            EmployeeId = 2,
                            FirstName = "Emp2",
                            FromDate = new DateTime(2022, 9, 9, 1, 22, 7, 94, DateTimeKind.Local).AddTicks(2415),
                            IsActive = true,
                            LastName = "Test2",
                            TeamId = 1
                        });
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.Certification", b =>
                {
                    b.HasOne("PortalPerfomanceEmployees.Models.Skill", "Skill")
                        .WithOne("Certification")
                        .HasForeignKey("PortalPerfomanceEmployees.Models.Certification", "SkillId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.EmployeeCertification", b =>
                {
                    b.HasOne("PortalPerfomanceEmployees.Models.Certification", "Certification")
                        .WithMany("EmployeeCertifications")
                        .HasForeignKey("CertificationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PortalPerfomanceEmployees.Models.Employee", "Employee")
                        .WithMany("EmployeeCertifications")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Certification");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.EmployeeSkill", b =>
                {
                    b.HasOne("PortalPerfomanceEmployees.Models.Employee", "Employee")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PortalPerfomanceEmployees.Models.Skill", "Skill")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PortalPerfomanceEmployees.Models.SkillLevel", "SkillLevel")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("SkillLevelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Skill");

                    b.Navigation("SkillLevel");
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.Skill", b =>
                {
                    b.HasOne("PortalPerfomanceEmployees.Models.SkillLevelType", "SkillLevelType")
                        .WithMany("Skills")
                        .HasForeignKey("SkillLevelTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalPerfomanceEmployees.Models.SkillType", "SkillType")
                        .WithMany("Skills")
                        .HasForeignKey("SkillTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SkillLevelType");

                    b.Navigation("SkillType");
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.SkillLevel", b =>
                {
                    b.HasOne("PortalPerfomanceEmployees.Models.SkillLevelType", "SkillLevelType")
                        .WithMany("SkillLevels")
                        .HasForeignKey("SkillLevelTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SkillLevelType");
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.TeamMember", b =>
                {
                    b.HasOne("PortalPerfomanceEmployees.Models.Employee", "Employee")
                        .WithMany("TeamMemberships")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PortalPerfomanceEmployees.Models.Team", "Team")
                        .WithMany("TeamMembers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.Certification", b =>
                {
                    b.Navigation("EmployeeCertifications");
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.Employee", b =>
                {
                    b.Navigation("EmployeeCertifications");

                    b.Navigation("EmployeeSkills");

                    b.Navigation("TeamMemberships");
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.Skill", b =>
                {
                    b.Navigation("Certification")
                        .IsRequired();

                    b.Navigation("EmployeeSkills");
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.SkillLevel", b =>
                {
                    b.Navigation("EmployeeSkills");
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.SkillLevelType", b =>
                {
                    b.Navigation("SkillLevels");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.SkillType", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("PortalPerfomanceEmployees.Models.Team", b =>
                {
                    b.Navigation("TeamMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
