using PortalPerfomanceEmployees.Repository;
using PortalPerfomanceEmployees.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AutoMapper;

namespace PortalPerfomanceEmployees.Services
{
    public class UserInfoServices
    {
        private readonly IMapper _mapper;
        private readonly EmployeeRepository _employeeRepository;
        private readonly TeamMemberRespository _teamMemberRespository;
        private readonly TeamRepository _teamRespository;
        public UserInfoServices(IMapper mapper, EmployeeRepository employeeRepository, TeamMemberRespository teamMemberRespository, TeamRepository teamRespository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _teamMemberRespository = teamMemberRespository;
            _teamRespository = teamRespository;
        }
        public string GetUserRole(ClaimsPrincipal user)
        {
            if (int.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var emp = _employeeRepository.GetById(id);
                if (emp != null)
                {
                    return user.FindFirst(ClaimTypes.Role)?.Value;
                }
            }
            return "";
        }

        public Employee GetUserProfile(ClaimsPrincipal user)
        {
            if (int.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var emp = _employeeRepository.GetById(id);
                return emp;
            }
            return null;
        }

        public Employee GetEmployeeProfile(int targetId, ClaimsPrincipal user)
        {
            if (int.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int empId))
            {
                var emp = _employeeRepository.GetById(empId);
                if (emp != null)
                {
                    var target = _employeeRepository.GetById(targetId);
                    if (emp.Role == Role.Admin)
                    {
                        return target;
                    }
                    else
                    {
                        var empTeam = _teamMemberRespository.TeamMemberActive(empId);
                        var targetTeam = _teamMemberRespository.TeamMemberActive(targetId); 
                        if (empTeam?.TeamId == null || targetTeam?.TeamId == null)
                        {
                            return null;
                        }
                        else if (empTeam.TeamId == targetTeam.TeamId)
                        {
                            return target;
                        }
                        return null;
                    }
                }
                return null;
            }
            return null;
        }

        public List<Employee> GetUserColleagues(ClaimsPrincipal user)
        {
            if (int.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var emp = _teamMemberRespository.TeamMemberActive(id);
                if (emp != null)
                {
                    var team = _teamMemberRespository.TeamActive(emp.TeamId);
                    var colleagues = new List<Employee>();
                    foreach (var colleague in team)
                    {
                        var employee = _employeeRepository.GetById(colleague.EmployeeId);
                        colleagues.Add(_mapper.Map<Employee>(employee));
                    }
                    return colleagues;
                }
                return null;
            }
            return null;
        }

        public string GetUserTeamName(ClaimsPrincipal user)
        {
            if (int.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var emp = _teamMemberRespository.TeamMemberActive(id);
                if (emp != null)
                {
                    var team = _teamRespository.GetTeamById(emp.TeamId);
                    if (team != null) { return team.TeamName; }
                    else { return ""; }
                }
                return "";
            }
            return "";
        }

        public List<TeamMember> GetUserTeamHistory(ClaimsPrincipal user)
        {
            if (int.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var emp = _teamMemberRespository.GetListTeamMember(id);
                return emp;
            }
            return null;
        }

        public Employee UpdateUserProfile(ClaimsPrincipal user, EmployeeUserUpdateDTO newEmp)
        {
            if (int.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var oldEmp = _employeeRepository.GetById(id);
                if (oldEmp == null)
                {
                    return oldEmp;
                }
                oldEmp = _mapper.Map<Employee>(newEmp);
                _employeeRepository.Update(oldEmp);
                return oldEmp;
            }
            return null;
        }
    }
}
