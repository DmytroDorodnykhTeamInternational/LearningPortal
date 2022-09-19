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
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<EmployeeCertification> EmployeeCertifications { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }
        public DbSet<SkillLevelType> SkillLevelTypes { get; set; }
        public DbSet<SkillType> SkillTypes { get; set; }
        public DbSet<CertificationSkill> CertificationSkills { get; set; }
    }
}