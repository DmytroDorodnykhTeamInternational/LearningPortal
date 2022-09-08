using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalPerfomanceEmployees.Data;
using PortalPerfomanceEmployees.Models;
using Microsoft.AspNetCore.Authorization;

namespace PortalPerfomanceEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var emp = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);
            return emp == null ? NotFound("Employee with specified ID was not found") : Ok(emp);
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
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

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var EmployeeToDelete = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);
            if (EmployeeToDelete == null) return NotFound("Employee specified that ID was not found");
            _context.Employees.Remove(EmployeeToDelete);
            await _context.SaveChangesAsync();
            return Ok(await GetEmployees());
        }
    }
}