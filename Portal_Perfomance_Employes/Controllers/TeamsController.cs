// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalPerfomanceEmployees.Data;
using PortalPerfomanceEmployees.Models;

namespace PortalPerfomanceEmployees.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles="Admin")]
public class TeamsController : ControllerBase
{
    private readonly AppDbContext _context;
    public TeamsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetTeams()
    {
        return Ok(await _context.Teams.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeam(int id)
    {
        var team = await _context.Teams
            .FirstOrDefaultAsync(t => t.TeamId == id);
        return team == null ? NotFound("The team with that ID was not found") : Ok(team);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeam(TeamDTO team)
    {
        Team newTeam = new Team();
        newTeam.DateCreated = DateTime.Now;
        newTeam.TeamName = team.TeamName;
        newTeam.Employees = new List<Employee>();
        _context.Teams.Add(newTeam);
        await _context.SaveChangesAsync();
        return Ok(await GetTeams());
    }

    [HttpPut("addMember/{id}")]
    public async Task<IActionResult> AddTeamMember(int employeeId, int teamId)
    {
        var employeeToAdd = await _context.Employees
            .FirstOrDefaultAsync(t => t.Id == employeeId);
        if (employeeToAdd == null) return NotFound("An employee with that ID does not exist");
        if (employeeToAdd.TeamId != null) return BadRequest("This employee already has a team");
        var team = await _context.Teams
            .FirstOrDefaultAsync(t => t.TeamId == teamId);
        if (team == null) return NotFound("A team with that ID does not exist");
        team.Employees.Add(employeeToAdd);
        await _context.SaveChangesAsync();
        return Ok(await GetTeam(teamId));
    }
    [HttpPut("removeMember/{id}")]
    public async Task<IActionResult> RemoveTeamMember(int TeamId, int EmployeeId)
    {
        var Team = await _context.Teams
            .FirstOrDefaultAsync(t => t.TeamId == TeamId);
        if (Team == null) return NotFound("A team with that ID does not exist");
        var EmployeeToRemove = Team.Employees
            .SingleOrDefault(e => e.Id == EmployeeId);
        if (EmployeeToRemove == null) return NotFound("This team does not have an employee with that ID");
        EmployeeToRemove.TeamId = null;
        Team.Employees.Remove(EmployeeToRemove);
        await _context.SaveChangesAsync();
        return Ok(await GetTeam(TeamId));
    }

    [HttpPut("setTl/{id}")]
    public async Task<IActionResult> SetTeamLeader(int teamId, int teamLeaderId)
    {
        var teamLeader = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == teamLeaderId);
        if (teamLeader == null) return NotFound("A team leader with that ID does not exist");
        if (teamLeader.Role != Role.Teamlead || teamLeader.Role != Role.Admin) return BadRequest("This employee is not a team leader");
        var Team = await _context.Teams
            .FirstOrDefaultAsync(t => t.TeamId == teamId);
        if (Team == null) return NotFound("A team with that ID does not exist");
        Team.TeamLeader.TeamId = null;
        Team.TeamLeader = teamLeader;
        teamLeader.TeamId = teamId;
        await _context.SaveChangesAsync();
        return Ok(await GetTeam(teamId));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeam(int id)
    {
        var teamToDelete = await _context.Teams
            .FirstOrDefaultAsync(t => t.TeamId == id);
        if (teamToDelete == null) return NotFound("A team with that ID was not found");
        foreach (Employee emp in teamToDelete.Employees)
        {
            emp.TeamId = null;
        }
        _context.Teams.Remove(teamToDelete);
        await _context.SaveChangesAsync();
        return Ok(await GetTeams());
    }
}
