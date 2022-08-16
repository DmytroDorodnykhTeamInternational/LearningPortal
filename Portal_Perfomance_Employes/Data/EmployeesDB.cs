using Portal_Perfomance_Employees.Models;

namespace Portal_Perfomance_Employees.Data
{
    public class EmployeesDB
    {
        public List<Employee> employees { get; set; }
        public void PopularEmployeesDB()
        {
            employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Emp1", Age = 25 , level = seniority.Junior, Created = DateTime.Now},
                new Employee { Id = 2, Name = "Emp2", Age = 30 , level = seniority.mid_level, Created = DateTime.Now},
                new Employee { Id = 3, Name = "Emp3", Age = 35 , level = seniority.Senior, Created = DateTime.Now}
            };
        }
    }
}
