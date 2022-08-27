using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Username = "emp", Password = "1234", EmailAddress = "emp@email.com", FirstName = "Emp1", LastName = "Test1", DateOfBirth = new DateTime(2000, 5, 20), Seniority = Seniority.Junior, Role = Role.Employee, Created = DateTime.Now },
                new Employee { Id = 2, Username = "teamlead", Password = "1234", EmailAddress = "teamlead@email.com", FirstName = "Emp2", LastName = "Test2", DateOfBirth = new DateTime(1980, 3, 28), Seniority = Seniority.MidLevel, Role = Role.Teamlead, Created = DateTime.Now },
                new Employee { Id = 3, Username = "admin", Password = "1234", EmailAddress = "admin@email.com", FirstName = "Emp3", LastName = "Test3", DateOfBirth = new DateTime(2005, 12, 5), Seniority = Seniority.Senior, Role = Role.Admin, Created = DateTime.Now }
                );
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}