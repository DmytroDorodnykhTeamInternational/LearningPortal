﻿using Microsoft.EntityFrameworkCore;
using PortalPerfomanceEmployees.Models;

namespace PortalPerfomanceEmployees.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                new Team { TeamId = 1, TeamName = "Team number one", DateCreated = new DateTime(2022, 08, 29), TeamLeaderId = 2 },
                new Team { TeamId = 2, TeamName = "Team number two", DateCreated = new DateTime(2022, 09, 10), TeamLeaderId = 11 }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Username = "emp",
                    Password = "1234",
                    EmailAddress = "emp@email.com",
                    FirstName = "Emp1",
                    LastName = "Test1",
                    DateOfBirth = new DateTime(2000, 5, 20),
                    Seniority = Seniority.Junior,
                    Role = Role.Employee,
                    Created = DateTime.Now
                },
                new Employee
                {
                    Id = 2,
                    Username = "teamlead",
                    Password = "1234",
                    EmailAddress = "teamlead@email.com",
                    FirstName = "Emp2",
                    LastName = "Test2",
                    DateOfBirth = new DateTime(1980, 3, 28),
                    Seniority = Seniority.MidLevel,
                    Role = Role.Teamlead,
                    Created = DateTime.Now
                },
                new Employee
                {
                    Id = 3,
                    Username = "admin",
                    Password = "1234",
                    EmailAddress = "admin@email.com",
                    FirstName = "Emp3",
                    LastName = "Test3",
                    DateOfBirth = new DateTime(2005, 12, 5),
                    Seniority = Seniority.Junior,
                    Role = Role.Admin,
                    Created = DateTime.Now
                },
                new Employee
                {
                    Id = 4,
                    Username = "emp2",
                    Password = "1234",
                    EmailAddress = "emp2@email.com",
                    FirstName = "Emp4",
                    LastName = "Test4",
                    DateOfBirth = new DateTime(1987, 3, 11),
                    Seniority = Seniority.Junior,
                    Role = Role.Employee,
                    Created = DateTime.Now
                },
                new Employee
                {
                    Id = 5,
                    Username = "emp3",
                    Password = "1234",
                    EmailAddress = "emp3@email.com",
                    FirstName = "Emp5",
                    LastName = "Test5",
                    DateOfBirth = new DateTime(1988, 7, 28),
                    Seniority = Seniority.MidLevel,
                    Role = Role.Employee,
                    Created = DateTime.Now
                },
                new Employee
                {
                    Id = 6,
                    Username = "emp4",
                    Password = "1234",
                    EmailAddress = "emp4@email.com",
                    FirstName = "Emp6",
                    LastName = "Test6",
                    DateOfBirth = new DateTime(2001, 10, 22),
                    Seniority = Seniority.MidLevel,
                    Role = Role.Employee,
                    Created = DateTime.Now
                },
                new Employee
                {
                    Id = 7,
                    Username = "emp5",
                    Password = "1234",
                    EmailAddress = "emp5@email.com",
                    FirstName = "Emp7",
                    LastName = "Test7",
                    DateOfBirth = new DateTime(2003, 5, 25),
                    Seniority = Seniority.Junior,
                    Role = Role.Employee,
                    Created = DateTime.Now
                },
                new Employee
                {
                    Id = 8,
                    Username = "emp6",
                    Password = "1234",
                    EmailAddress = "emp6@email.com",
                    FirstName = "Emp8",
                    LastName = "Test8",
                    DateOfBirth = new DateTime(1980, 3, 28),
                    Seniority = Seniority.MidLevel,
                    Role = Role.Teamlead,
                    Created = DateTime.Now
                },
                new Employee
                {
                    Id = 9,
                    Username = "emp7",
                    Password = "1234",
                    EmailAddress = "emp7@email.com",
                    FirstName = "Emp9",
                    LastName = "Test9",
                    DateOfBirth = new DateTime(2005, 12, 5),
                    Seniority = Seniority.Senior,
                    Role = Role.Admin,
                    Created = DateTime.Now
                },
                new Employee
                {
                    Id = 10,
                    Username = "emp8",
                    Password = "1234",
                    EmailAddress = "emp8@email.com",
                    FirstName = "Emp10",
                    LastName = "Test10",
                    DateOfBirth = new DateTime(2000, 5, 20),
                    Seniority = Seniority.Junior,
                    Role = Role.Employee,
                    Created = DateTime.Now
                },
                new Employee
                {
                    Id = 11,
                    Username = "teamlead2",
                    Password = "1234",
                    EmailAddress = "teamlead2@email.com",
                    FirstName = "Emp11",
                    LastName = "Test11",
                    DateOfBirth = new DateTime(1980, 3, 28),
                    Seniority = Seniority.MidLevel,
                    Role = Role.Teamlead,
                    Created = DateTime.Now
                },
                new Employee
                {
                    Id = 12,
                    Username = "admin2",
                    Password = "1234",
                    EmailAddress = "admin2@email.com",
                    FirstName = "Emp12",
                    LastName = "Test12",
                    DateOfBirth = new DateTime(2005, 12, 5),
                    Seniority = Seniority.Senior,
                    Role = Role.Admin,
                    Created = DateTime.Now
                }
                );
            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember { Id = 1, EmployeeId = 1, TeamId = 1, FirstName = "Emp1", LastName = "Test1", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { Id = 2, EmployeeId = 2, TeamId = 1, FirstName = "Emp2", LastName = "Test2", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { Id = 3, EmployeeId = 11, TeamId = 1, FirstName = "Emp11", LastName = "Test11", FromDate = new DateTime(2022, 08, 29), ToDate = DateTime.Now, IsActive = false },
                new TeamMember { Id = 4, EmployeeId = 5, TeamId = 1, FirstName = "Emp5", LastName = "Test5", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { Id = 5, EmployeeId = 6, TeamId = 1, FirstName = "Emp6", LastName = "Test6", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { Id = 6, EmployeeId = 7, TeamId = 2, FirstName = "Emp7", LastName = "Test7", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { Id = 7, EmployeeId = 8, TeamId = 2, FirstName = "Emp8", LastName = "Test8", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { Id = 8, EmployeeId = 9, TeamId = 2, FirstName = "Emp9", LastName = "Test9", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { Id = 9, EmployeeId = 10, TeamId = 2, FirstName = "Emp10", LastName = "Test10", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { Id = 10, EmployeeId = 11, TeamId = 2, FirstName = "Emp11", LastName = "Test11", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { Id = 11, EmployeeId = 4, TeamId = 2, FirstName = "Emp4", LastName = "Test4", FromDate = DateTime.Now, IsActive = true }
                );
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
    }
}