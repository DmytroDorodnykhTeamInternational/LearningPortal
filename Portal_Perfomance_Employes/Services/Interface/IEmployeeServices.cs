using PortalPerfomanceEmployees.Models;

namespace PortalPerfomanceEmployees.Services
{
    public interface IEmployeeServices
    {
        Task<List<Employee>> GetAll();
        Task Create(EmployeeDTO employee);
        Task<bool> Update(EmployeeDTO employee, int id);
        Task<bool> Delete(int id);
    }
}
