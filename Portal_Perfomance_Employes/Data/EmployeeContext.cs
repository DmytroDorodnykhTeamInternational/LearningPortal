// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.
using Microsoft.EntityFrameworkCore;
using PortalPerfomanceEmployees.Models;

namespace PortalPerfomanceEmployees.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "Emp1", LastName = "Test1", DateOfBirth = new DateTime(2000, 5, 20), Seniority = Seniority.Junior, Role = Role.Employee, Created = DateTime.Now },
                new Employee { Id = 2, FirstName = "Emp2", LastName = "Test2", DateOfBirth = new DateTime(1980, 3, 28), Seniority = Seniority.MidLevel, Role = Role.Teamlead, Created = DateTime.Now },
                new Employee { Id = 3, FirstName = "Emp3", LastName = "Test3", DateOfBirth = new DateTime(2005, 12, 5), Seniority = Seniority.Senior, Role = Role.Admin, Created = DateTime.Now }
                );
        }
        public DbSet<Employee> Employees { get; set; }
    }
}