﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalPerfomanceEmployees.Data;
using PortalPerfomanceEmployees.Models;

namespace PortalPerfomanceEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            newEmployee.TeamId = employee.TeamId != null ? employee.TeamId : null;
            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();
            return Ok(await GetEmployees());
        }

        [HttpPut("{id}")]
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
            EmployeeToUpdate.TeamId = employee.TeamId;
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
            await _context.SaveChangesAsync();
            return Ok(await GetEmployees());
        }
    }
}
