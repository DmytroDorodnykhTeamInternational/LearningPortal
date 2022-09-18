using AutoMapper;
using PortalPerfomanceEmployees.Models;

namespace PortalPerfomanceEmployees.Config
{
    public class ConfigMapper : Profile
    {
        public ConfigMapper()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}