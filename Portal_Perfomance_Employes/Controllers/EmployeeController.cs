using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal_Perfomance_Employees.Data;
using Portal_Perfomance_Employees.Models;

namespace Portal_Perfomance_Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeesDB _employeesDB = new EmployeesDB();

        public EmployeeController()
        {
            _employeesDB.PopularEmployeesDB();
        }


        [HttpGet]
        public async Task<IEnumerable<Employee>> Get() => _employeesDB.employees.ToList();
        
        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {

            Employee emp = _employeesDB.employees.Find(x => x.Id == id);

            return emp == null ? NotFound() : Ok(emp) ;
        }


        [HttpPost]
        public async Task<IEnumerable<Employee>> CreateEmployee(Employee employee)
        {
            _employeesDB.employees.Add(employee);
            return _employeesDB.employees.ToList();
        }

        [HttpPut("{id}")]
        public async Task<IEnumerable<Employee>> UpdateEmployee(int id, Employee employee)
        {

            int index = _employeesDB.employees.FindIndex(s => s.Id == id);

            if (index != -1)
                _employeesDB.employees[index] = employee;
            
            return _employeesDB.employees.ToList();
        }


        [HttpDelete("{id}")]
        public async Task<IEnumerable<Employee>> DeleteEmployee(int id)
        {

            int index = _employeesDB.employees.FindIndex(s => s.Id == id);

            _employeesDB.employees.RemoveAt(index);

            return _employeesDB.employees.ToList();
        }

    }
}
