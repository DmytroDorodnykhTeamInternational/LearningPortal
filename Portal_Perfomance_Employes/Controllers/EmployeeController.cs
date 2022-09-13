using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalPerfomanceEmployees.Data;
using PortalPerfomanceEmployees.Models;
using Microsoft.AspNetCore.Authorization;

namespace PortalPerfomanceEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDTO employee)
        {
            Employee newEmployee = new Employee();
            newEmployee.Username = employee.Username;
            newEmployee.Password = employee.Password;
            newEmployee.EmailAddress = employee.EmailAddress;
            newEmployee.FirstName = employee.FirstName;
            newEmployee.LastName = employee.LastName;
            newEmployee.DateOfBirth = (DateTime)employee.DateOfBirth;
            newEmployee.Seniority = (Seniority)employee.Seniority;
            newEmployee.Role = (Role)employee.Role;
            newEmployee.Created = DateTime.Now;
            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();
            return Ok(await GetEmployees());
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDTO employee, int id)
        {
            var EmployeeToUpdate = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);
            if (EmployeeToUpdate == null) return NotFound("Employee specified that ID was not found");
            EmployeeToUpdate.Username = employee.Username;
            EmployeeToUpdate.Password = employee.Password;
            EmployeeToUpdate.EmailAddress = employee.EmailAddress;
            EmployeeToUpdate.FirstName = employee.FirstName;
            EmployeeToUpdate.LastName = employee.LastName;
            EmployeeToUpdate.DateOfBirth = (DateTime)employee.DateOfBirth;
            EmployeeToUpdate.Seniority = (Seniority)employee.Seniority;
            EmployeeToUpdate.Role = (Role)employee.Role;
            await _context.SaveChangesAsync();
            return Ok(await GetEmployees());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var EmployeeToDelete = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);
            if (EmployeeToDelete == null) return NotFound("Employee specified that ID was not found");
            _context.Employees.Remove(EmployeeToDelete);
            var teamMemberships = await _context.TeamMembers.Where(x => x.EmployeeId == id).ToListAsync();
            foreach (var teamMembership in teamMemberships)
            {
                _context.TeamMembers.Remove(teamMembership);
            }
            await _context.SaveChangesAsync();
            return Ok(await GetEmployees());
        }
    }
}