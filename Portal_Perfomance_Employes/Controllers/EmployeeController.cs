using PortalPerfomanceEmployees.Services;
using Microsoft.AspNetCore.Authorization;
using PortalPerfomanceEmployees.Models;
using Microsoft.AspNetCore.Mvc;

namespace PortalPerfomanceEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;
        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _employeeServices.GetAll();
                if (employees.Count() == 0) return NotFound();
                else return Ok(employees);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDTO employee)
        {
            if (employee == null) return BadRequest();
            try
            {
                await _employeeServices.Create(employee);
                return Ok(await GetEmployees());
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDTO employee, int id)
        {
            if (id == 0) return BadRequest();
            if (employee == null) return BadRequest();
            try
            {
                var worked = await _employeeServices.Update(employee, id);
                if (worked) Ok(await GetEmployees());
                return NotFound("Employee specified that ID was not found");
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                var worked = await _employeeServices.Delete(id);
                if (worked) Ok(await GetEmployees());
                return NotFound("Employee specified that ID was not found");
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}