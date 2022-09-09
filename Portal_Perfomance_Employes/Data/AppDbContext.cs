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
            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(f => f.SkillLevel)
                .WithMany(s => s.EmployeeSkills)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<TeamMember>()
                .HasOne(f => f.Team)
                .WithMany(s => s.TeamMembers)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<TeamMember>()
                .HasOne(f => f.Employee)
                .WithMany(s => s.TeamMemberships)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EmployeeCertification>()
                .HasOne(f => f.Employee)
                .WithMany(s => s.EmployeeCertifications)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EmployeeCertification>()
                .HasOne(f => f.Certification)
                .WithMany(s => s.EmployeeCertifications)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Certification>()
                .HasOne(f => f.Skill)
                .WithOne(s => s.Certification)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(f => f.Employee)
                .WithMany(s => s.EmployeeSkills)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SkillType>()
                .HasMany(f => f.Skills)
                .WithOne(s => s.SkillType)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Skill>()
                .HasMany(f => f.EmployeeSkills)
                .WithOne(s => s.Skill)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(f => f.SkillLevel)
                .WithMany(s => s.EmployeeSkills)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SkillLevel>()
                .HasOne(f => f.SkillLevelType)
                .WithMany(s => s.SkillLevels)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Team>().HasData(
                new Team { TeamId = 1, TeamName = "Team number one", DateCreated = new DateTime(2022, 08, 29), TeamLeaderId = 2 }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Username = "emp", Password = "1234", EmailAddress = "emp@email.com", FirstName = "Emp1", LastName = "Test1", DateOfBirth = new DateTime(2000, 5, 20), Seniority = Seniority.Junior, Role = Role.Employee, Created = DateTime.Now },
                new Employee { Id = 2, Username = "teamlead", Password = "1234", EmailAddress = "teamlead@email.com", FirstName = "Emp2", LastName = "Test2", DateOfBirth = new DateTime(1980, 3, 28), Seniority = Seniority.MidLevel, Role = Role.Teamlead, Created = DateTime.Now },
                new Employee { Id = 3, Username = "admin", Password = "1234", EmailAddress = "admin@email.com", FirstName = "Emp3", LastName = "Test3", DateOfBirth = new DateTime(2005, 12, 5), Seniority = Seniority.Senior, Role = Role.Admin, Created = DateTime.Now }
                );
            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember { Id = 1, EmployeeId = 1, TeamId = 1, FirstName = "Emp1", LastName = "Test1", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { Id = 2, EmployeeId = 2, TeamId = 1, FirstName = "Emp2", LastName = "Test2", FromDate = DateTime.Now, IsActive = true }
                );
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Certification> Certification { get; set; }
        public DbSet<EmployeeCertification> EmployeeCertification { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkill { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<SkillLevel> SkillLevel { get; set; }
        public DbSet<SkillLevelType> SkillLevelType { get; set; }
        public DbSet<SkillType> SkillType { get; set; }
    }
}