using PortalPerfomanceEmployees.Models;
using PortalPerfomanceEmployees.Data;
using Microsoft.EntityFrameworkCore;

namespace PortalPerfomanceEmployees.Repository
{
    public class EmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task Create(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
        public async Task Update()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
        public void DeleteEmployeeTeamMenbers(int id)
        {
            _context.TeamMembers.RemoveRange(_context.TeamMembers.Where(x => x.EmployeeId == id));
        }
    }
}
