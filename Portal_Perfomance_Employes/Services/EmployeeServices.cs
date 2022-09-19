using PortalPerfomanceEmployees.Repository;
using PortalPerfomanceEmployees.Models;
using AutoMapper;

namespace PortalPerfomanceEmployees.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IMapper _mapper;
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeServices(IMapper mapper, EmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }
        public async Task<List<Employee>> GetAll()
        {
            try
            {
                return await _employeeRepository.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task Create(EmployeeDTO employee)
        {
            try
            {
                Employee newEmployee = _mapper.Map<Employee>(employee);
                await _employeeRepository.Create(newEmployee);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var EmployeeToDelete = _employeeRepository.GetById(id);
                if (EmployeeToDelete == null) return false;
                await _employeeRepository.Delete(EmployeeToDelete);
                _employeeRepository.DeleteEmployeeTeamMenbers(EmployeeToDelete.Id);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<bool> Update(EmployeeDTO employee, int id)
        {
            try
            {
                var EmployeeToUpdate = _employeeRepository.GetById(id);
                if (EmployeeToUpdate == null) return false;
                EmployeeToUpdate = _mapper.Map<Employee>(employee);
                await _employeeRepository.Update(EmployeeToUpdate);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
