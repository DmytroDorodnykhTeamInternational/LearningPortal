using PortalPerfomanceEmployees.Models;
using PortalPerfomanceEmployees.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace PortalPerfomanceEmployees.Repository
{
    public class EmployeeRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public async Task<bool> Update(Employee employee)
        {
            _context.Attach(employee);
            await _context.SaveChangesAsync();
            return true;
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
