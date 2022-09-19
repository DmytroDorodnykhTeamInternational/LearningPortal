using PortalPerfomanceEmployees.Models;
using PortalPerfomanceEmployees.Data;

namespace PortalPerfomanceEmployees.Repository
{
    public class EmployeeSkillRepository
    {
        private readonly AppDbContext _context;

        public EmployeeSkillRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<EmployeeSkill> GetEmployeeSkillsOfEmployee(int id)
        {
            return _context.EmployeeSkills.Where(e => e.EmployeeId == id).ToList();
        }

        public int Create(EmployeeSkill employeeSkill)
        {
            _context.EmployeeSkills.Add(employeeSkill);
            _context.SaveChanges();
            return employeeSkill.EmployeeId;
        }
    }
}
