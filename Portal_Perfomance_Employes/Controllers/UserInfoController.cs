// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalPerfomanceEmployees.Data;
using PortalPerfomanceEmployees.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace PortalPerfomanceEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserInfoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserInfoController(AppDbContext context)
        {
            _context = context;
        }

        [Route("GetUserRole")]
        [HttpGet]
        public async Task<IActionResult> GetUserRole()
        {
            if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var emp = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
                if (emp == null)
                {
                    return StatusCode(403, "Error! ID of authorized user was not found");
                }
                else if (emp?.Role == null)
                {
                    return StatusCode(403, "Error! Token is corrupt. Role of authorized user was not found");
                }
                else
                {
                    return Ok(User.FindFirst(ClaimTypes.Role)?.Value);
                }
            }
            return StatusCode(403, "Error! Token is corrupt. ID of authorized user was not found");
        }

        [Route("GetUserProfile")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfile()
        {
            if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var emp = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
                return emp != null ? Ok(emp) : StatusCode(403, "Error! ID of authorized user was not found");
            }
            return StatusCode(403, "Error! Token is corrupt. ID of authorized user was not found");
        }

        [Route("GetEmployeeProfile")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeProfile(int targetId)
        {
            if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int empId))
            {
                var emp = await _context.Employees.FirstOrDefaultAsync(e => e.Id == empId);
                if (emp != null)
                {
                    var target = await _context.Employees.FirstOrDefaultAsync(t => t.Id == targetId);
                    if (target == null)
                    {
                        return NotFound("Employee with specified ID was not found");
                    }
                    else if (emp.Role == Role.Admin)
                    {
                        return Ok(target);
                    }
                    else
                    {
                        var empTeam = await _context.TeamMembers.FirstOrDefaultAsync(e => e.EmployeeId == empId && e.IsActive);
                        var targetTeam = await _context.TeamMembers.FirstOrDefaultAsync(t => t.EmployeeId == targetId && t.IsActive);
                        if (empTeam?.TeamId == null || targetTeam?.TeamId == null)
                        {
                            return StatusCode(403, "You do not have permission to view this profile");
                        }
                        else if (empTeam.TeamId == targetTeam.TeamId)
                        {
                            // Clearing targetTeam to not get fill "teamMemberships" value in response
                            targetTeam = null;
                            return Ok(target);
                        }
                        return StatusCode(403, "You do not have permission to view this profile");
                    }
                }
                return StatusCode(403, "Error! ID of authorized user was not found");
            }
            return StatusCode(403, "Error! Token is corrupt. ID of authorized user was not found");
        }

        [Route("GetUserColleagues")]
        [HttpGet]
        public async Task<IActionResult> GetUserColleagues()
        {
            if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var emp = await _context.TeamMembers.FirstOrDefaultAsync(e => e.EmployeeId == id && e.IsActive);
                if (emp != null)
                {
                    var team = await _context.TeamMembers.Where(t => t.TeamId == emp.TeamId && t.IsActive).ToListAsync();

                    var colleagues = new List<Employee>();
                    foreach (var colleague in team)
                    {
                        var employee = await _context.Employees.Where(e => e.Id == colleague.EmployeeId).FirstOrDefaultAsync();
                        colleagues.Add(
                            new Employee
                            {
                                Id = employee.Id,
                                Username = employee.Username,
                                EmailAddress = employee.EmailAddress,
                                FirstName = employee.FirstName,
                                LastName = employee.LastName,
                                DateOfBirth = employee.DateOfBirth,
                                Seniority = employee.Seniority,
                                Role = employee.Role,
                            });
                    }
                    return colleagues == null ? NotFound("Something went wrong") : Ok(colleagues);
                }
                return NotFound("The team with that ID was not found");
            }
            return StatusCode(403, "Error! Token is corrupt. ID of authorized user was not found");
        }

        [Route("GetUserTeamName")]
        [HttpGet]
        public async Task<IActionResult> GetUserTeamName()
        {
            if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var emp = await _context.TeamMembers.FirstOrDefaultAsync(e => e.EmployeeId == id && e.IsActive);
                if (emp != null)
                {
                    var team = await _context.Teams.FirstOrDefaultAsync(c => c.TeamId == emp.TeamId);
                    return team == null ? StatusCode(403, "Something went wrong") : Ok(team.TeamName);
                }
                return NotFound("Сurrent user is not assigned to any team");
            }
            return StatusCode(403, "Error! Token is corrupt. ID of authorized user was not found");
        }

        [Route("GetUserTeamHistory")]
        [HttpGet]
        public async Task<IActionResult> GetUserTeamHistory()
        {
            if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var emp = await _context.TeamMembers.Where(e => e.EmployeeId == id).ToListAsync();
                return (emp == null) ? NotFound("Сurrent user has never been assigned to a team") : Ok(emp);
            }
            return StatusCode(403, "Error! Token is corrupt. ID of authorized user was not found");
        }

        [Route("UpdateUserProfile")]
        [HttpPost]
        public async Task<IActionResult> UpdateUserProfile(EmployeeUserUpdateDTO newEmp)
        {
            if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var oldEmp = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
                if (oldEmp == null)
                {
                    return StatusCode(403, "Error! ID of authorized user was not found");
                }
                oldEmp.Username = newEmp.Username;
                oldEmp.Password = newEmp.Password;
                oldEmp.EmailAddress = newEmp.EmailAddress;
                oldEmp.FirstName = newEmp.FirstName;
                oldEmp.LastName = newEmp.LastName;
                await _context.SaveChangesAsync();
                return Ok(oldEmp);
            }
            return StatusCode(403, "Error! Token is corrupt. ID of authorized user was not found");
        }
    }
}