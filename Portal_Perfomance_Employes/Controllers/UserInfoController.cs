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
        public IActionResult GetUserRole()
        {
            return Ok(User.FindFirst(ClaimTypes.Role)?.Value);
        }

        [Route("GetUserProfile")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfile()
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id);
            var emp = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);
            return emp == null ? NotFound("Employee with specified ID was not found") : Ok(emp);
        }

        [Route("GetUserColleagues")]
        [HttpGet]
        public async Task<IActionResult> GetUserColleagues()
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id);
            var emp = await _context.TeamMembers
                .FirstOrDefaultAsync(e => e.EmployeeId == id && e.IsActive);
            if (emp != null)
            {
                var colleagues = await _context.TeamMembers.Where(c => c.TeamId == emp.TeamId && c.IsActive).ToListAsync();
                return colleagues == null ? NotFound("Something went wrong") : Ok(colleagues);
            }
            return NotFound("The team with that ID was not found");
        }

        [Route("GetUserTeamName")]
        [HttpGet]
        public async Task<IActionResult> GetUserTeamName()
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id);
            var emp = await _context.TeamMembers
                .FirstOrDefaultAsync(e => e.EmployeeId == id && e.IsActive);
            if (emp != null)
            {
                var team = await _context.Teams.FirstOrDefaultAsync(c => c.TeamId == emp.TeamId);
                return team == null ? NotFound("Something went wrong") : Ok(team.TeamName);
            }
            return NotFound("Сurrent user is not assigned to any team");
        }

        [Route("GetUserTeamHistory")]
        [HttpGet]
        public async Task<IActionResult> GetUserTeamHistory()
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id);
            var emp = await _context.TeamMembers.Where(e => e.EmployeeId == id).ToListAsync();
            return (emp == null) ? NotFound("Сurrent user has never been assigned to a team") : Ok(emp);
        }

        [Route("UpdateUserProfile")]
        [HttpPost]
        public async Task<IActionResult> UpdateUserProfile(EmployeeUserUpdateDTO newEmp)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id);
            var oldEmp = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);
            if (oldEmp == null) return NotFound("Employee specified that ID was not found");
            oldEmp.Username = newEmp.Username;
            oldEmp.Password = newEmp.Password;
            oldEmp.EmailAddress = newEmp.EmailAddress;
            oldEmp.FirstName = newEmp.FirstName;
            oldEmp.LastName = newEmp.LastName;
            await _context.SaveChangesAsync();
            return Ok(oldEmp);
        }
    }
}