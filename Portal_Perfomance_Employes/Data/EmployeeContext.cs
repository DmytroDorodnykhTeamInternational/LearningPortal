using Microsoft.EntityFrameworkCore;
using PortalPerfomanceEmployees.Models;

namespace PortalPerfomanceEmployees.Data;

public class EmployeeContext : DbContext
{
    public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Name = "Emp1", Age = 25, Level = Seniority.Junior, Created = DateTime.Now },
            new Employee { Id = 2, Name = "Emp2", Age = 30, Level = Seniority.MidLevel, Created = DateTime.Now },
            new Employee { Id = 3, Name = "Emp3", Age = 35, Level = Seniority.Senior, Created = DateTime.Now }
            );
    }
    public DbSet<Employee> Employees { get; set; }
}
