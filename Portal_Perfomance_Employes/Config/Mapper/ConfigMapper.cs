using PortalPerfomanceEmployees.Models;
using AutoMapper;

namespace PortalPerfomanceEmployees.Config.Mapper
{
    public class ConfigMapper : Profile
    {
        public ConfigMapper()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}