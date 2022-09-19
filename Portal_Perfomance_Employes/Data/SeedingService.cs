using PortalPerfomanceEmployees.Models;

namespace PortalPerfomanceEmployees.Data
{
    public class SeedingService
    {
        private readonly AppDbContext _context;
        public SeedingService(AppDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Employees.Any())
            {
                _context.Employees.AddRange(CreateEmployee());
                _context.Teams.AddRange(CreateTeam());
                _context.SkillTypes.AddRange(CreateSkillType());
                _context.SkillLevelTypes.AddRange(CreateSkillLevelType());
                _context.SaveChanges();
                _context.TeamMembers.AddRange(CreateTeamMember());
                _context.SkillLevels.AddRange(CreateSkillLevel());
                _context.Skills.AddRange(CreateSkill());
                _context.SaveChanges();
                _context.EmployeeSkills.AddRange(CreateEmployeeSkill());
                //_context.CertificationSkills.AddRange(CreateCertificationSkill());
                //_context.Certifications.AddRange(CreateCertification());
                _context.SaveChanges();
            }
        }


        private List<Employee> CreateEmployee()
        {
            List<Employee> employeeList = new() {
                new Employee
                {
                    Username = "emp", Password = "1234", EmailAddress = "emp@email.com",
                    FirstName = "Emp1", LastName = "Test1", DateOfBirth = new DateTime(2000, 5, 20),
                    Seniority = Seniority.Junior, Role = Role.Employee, Created = DateTime.Now
                },
                new Employee
                {
                    Username = "teamlead", Password = "1234", EmailAddress = "teamlead@email.com",
                    FirstName = "Emp2", LastName = "Test2", DateOfBirth = new DateTime(1980, 3, 28),
                    Seniority = Seniority.MidLevel, Role = Role.Teamlead, Created = DateTime.Now
                },
                new Employee
                {
                    Username = "admin", Password = "1234", EmailAddress = "admin@email.com",
                    FirstName = "Emp3", LastName = "Test3", DateOfBirth = new DateTime(2005, 12, 5),
                    Seniority = Seniority.Junior, Role = Role.Admin, Created = DateTime.Now
                },
                new Employee
                {
                    Username = "emp2", Password = "1234", EmailAddress = "emp2@email.com",
                    FirstName = "Emp4", LastName = "Test4", DateOfBirth = new DateTime(1987, 3, 11),
                    Seniority = Seniority.Junior, Role = Role.Employee, Created = DateTime.Now
                },
                new Employee
                {
                    Username = "emp3", Password = "1234", EmailAddress = "emp3@email.com",
                    FirstName = "Emp5", LastName = "Test5", DateOfBirth = new DateTime(1988, 7, 28),
                    Seniority = Seniority.MidLevel, Role = Role.Employee, Created = DateTime.Now
                },
                new Employee
                {
                    Username = "emp4", Password = "1234", EmailAddress = "emp4@email.com",
                    FirstName = "Emp6", LastName = "Test6", DateOfBirth = new DateTime(2001, 10, 22),
                    Seniority = Seniority.MidLevel, Role = Role.Employee, Created = DateTime.Now
                },
                new Employee
                {
                    Username = "emp5", Password = "1234", EmailAddress = "emp5@email.com",
                    FirstName = "Emp7", LastName = "Test7", DateOfBirth = new DateTime(2003, 5, 25),
                    Seniority = Seniority.Junior, Role = Role.Employee, Created = DateTime.Now
                },
                new Employee
                {
                    Username = "emp6", Password = "1234", EmailAddress = "emp6@email.com",
                    FirstName = "Emp8", LastName = "Test8", DateOfBirth = new DateTime(1980, 3, 28),
                    Seniority = Seniority.MidLevel, Role = Role.Teamlead, Created = DateTime.Now
                },
                new Employee
                {
                    Username = "emp7", Password = "1234", EmailAddress = "emp7@email.com",
                    FirstName = "Emp9", LastName = "Test9", DateOfBirth = new DateTime(2005, 12, 5),
                    Seniority = Seniority.Senior, Role = Role.Admin, Created = DateTime.Now
                },
                new Employee
                {
                    Username = "emp8", Password = "1234", EmailAddress = "emp8@email.com",
                    FirstName = "Emp10", LastName = "Test10", DateOfBirth = new DateTime(2000, 5, 20),
                    Seniority = Seniority.Junior, Role = Role.Employee, Created = DateTime.Now
                },
                new Employee
                {
                    Username = "teamlead2", Password = "1234", EmailAddress = "teamlead2@email.com",
                    FirstName = "Emp11", LastName = "Test11", DateOfBirth = new DateTime(1980, 3, 28),
                    Seniority = Seniority.MidLevel, Role = Role.Teamlead, Created = DateTime.Now
                },
                new Employee
                {
                    Username = "admin2", Password = "1234", EmailAddress = "admin2@email.com",
                    FirstName = "Emp12", LastName = "Test12", DateOfBirth = new DateTime(2005, 12, 5),
                    Seniority = Seniority.Senior, Role = Role.Admin, Created = DateTime.Now
                }
            };
            return employeeList;
        }

        private List<TeamMember> CreateTeamMember()
        {
            List<TeamMember> teamMembers = new() {
                new TeamMember { EmployeeId = 1, TeamId = 1, FirstName = "Emp1", LastName = "Test1", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { EmployeeId = 2, TeamId = 1, FirstName = "Emp2", LastName = "Test2", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { EmployeeId = 11, TeamId = 1, FirstName = "Emp11", LastName = "Test11", FromDate = DateTime.Now, ToDate = DateTime.Now, IsActive = false },
                new TeamMember { EmployeeId = 5, TeamId = 1, FirstName = "Emp5", LastName = "Test5", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { EmployeeId = 6, TeamId = 1, FirstName = "Emp6", LastName = "Test6", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { EmployeeId = 7, TeamId = 2, FirstName = "Emp7", LastName = "Test7", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { EmployeeId = 8, TeamId = 2, FirstName = "Emp8", LastName = "Test8", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { EmployeeId = 9, TeamId = 2, FirstName = "Emp9", LastName = "Test9", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { EmployeeId = 10, TeamId = 2, FirstName = "Emp10", LastName = "Test10", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { EmployeeId = 11, TeamId = 2, FirstName = "Emp11", LastName = "Test11", FromDate = DateTime.Now, IsActive = true },
                new TeamMember { EmployeeId = 4, TeamId = 2, FirstName = "Emp4", LastName = "Test4", FromDate = DateTime.Now, IsActive = true }
            };
            return teamMembers;
        }

        private List<Team> CreateTeam()
        {
            List<Team> team = new() {
                new Team { TeamName = "Team number one", DateCreated = new DateTime(2022, 08, 29), TeamLeaderId = 2 },
                new Team { TeamName = "Team number two", DateCreated = new DateTime(2022, 09, 10), TeamLeaderId = 11 }
            };
            return team;
        }

        private List<EmployeeSkill> CreateEmployeeSkill()
        {
            List<EmployeeSkill> employeeSkill = new() {
                new EmployeeSkill { EmployeeId = 1, SkillId = 1, SkillLevelId = 1 },
                new EmployeeSkill { EmployeeId = 1, SkillId = 2, SkillLevelId = 7 }
            };
            return employeeSkill;
        }

        private List<SkillLevelType> CreateSkillLevelType()
        {
            List<SkillLevelType> skillLevelType = new() {
                new SkillLevelType { SkillLevelTypeName = "Language" },
                new SkillLevelType { SkillLevelTypeName = "Technology" }
            };
            return skillLevelType;
        }

        private List<SkillType> CreateSkillType()
        {
            List<SkillType> skillType = new() {
                new SkillType { SkillTypeName = "Hard Skill" },
                new SkillType { SkillTypeName = "Soft Skill" }
            };
            return skillType;
        }

        private List<SkillLevel> CreateSkillLevel()
        {
            List<SkillLevel> skillLevel = new() {
                new SkillLevel { SkillLevelTypeId = 1, SkillLevelName = "A1" },
                new SkillLevel { SkillLevelTypeId = 1, SkillLevelName = "A2" },
                new SkillLevel { SkillLevelTypeId = 1, SkillLevelName = "B1" },
                new SkillLevel { SkillLevelTypeId = 1, SkillLevelName = "B2" },
                new SkillLevel { SkillLevelTypeId = 1, SkillLevelName = "C1" },
                new SkillLevel { SkillLevelTypeId = 1, SkillLevelName = "C2" },
                new SkillLevel { SkillLevelTypeId = 2, SkillLevelName = "Novice" },
                new SkillLevel { SkillLevelTypeId = 2, SkillLevelName = "Beginner" },
                new SkillLevel { SkillLevelTypeId = 2, SkillLevelName = "Competent" },
                new SkillLevel { SkillLevelTypeId = 2, SkillLevelName = "Proficient" },
                new SkillLevel { SkillLevelTypeId = 2, SkillLevelName = "Expert" }
            };
            return skillLevel;
        }

        private List<Skill> CreateSkill()
        {
            List<Skill> skill = new() {
                new Skill { SkillLevelTypeId = 1, SkillName = "English proficiency", SkillTypeId = 2 },
                new Skill { SkillLevelTypeId = 2, SkillName = "Microsoft Azure architecture", SkillTypeId = 1 },
                new Skill { SkillLevelTypeId = 2, SkillName = "C#/.NET programming", SkillTypeId = 1 }
            };
            return skill;
        }

        private List<CertificationSkill> CreateCertificationSkill()
        {
            List<CertificationSkill> certificationSkill = new() {
                new CertificationSkill { CertificationId = 1, SkillId = 2 },
                new CertificationSkill { CertificationId = 2, SkillId = 3 },
                new CertificationSkill { CertificationId = 3, SkillId = 1 }
            };
            return certificationSkill;
        }

        private List<Certification> CreateCertification()
        {
            List<Certification> certification = new() {
                new Certification { CertificationName = "AZ-301 Microsoft Azure Architect Design", CertificationSkillId = 1 },
                new Certification { CertificationName = "70-483: Programming in C#", CertificationSkillId = 2 },
                new Certification { CertificationName = "Cambridge English: Advanced", CertificationSkillId = 3 }
            };
            return certification;
        }
    }
}
