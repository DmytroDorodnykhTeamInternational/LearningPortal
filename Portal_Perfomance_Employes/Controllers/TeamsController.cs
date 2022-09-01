using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalPerfomanceEmployees.Data;
using PortalPerfomanceEmployees.Models;

namespace PortalPerfomanceEmployees.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
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

    [HttpGet("getTeamMembers/{id}")]
    public async Task<IActionResult> GetTeamMembers(int id)
    {
        var team = await _context.Teams
            .FirstOrDefaultAsync(t => t.TeamId == id);
        if (team == null) return NotFound("The team with that ID was not found");
        var teamMembers = await _context.TeamMembers
            .Where(tm => tm.TeamId == id && tm.IsActive)
            .ToListAsync();
        var teamMemberList = new List<TeamMemberDTO>();
        foreach (var member in teamMembers)
        {
            teamMemberList.Add(
                new TeamMemberDTO
                {
                    TeamId = member.TeamId,
                    EmployeeId = member.EmployeeId,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    FromDate = member.FromDate
                });
        }
        return Ok(teamMemberList);
    }

    [HttpPost("addTeam")]
    public async Task<IActionResult> CreateTeam(TeamDTO team)
    {
        Team newTeam = new Team();
        newTeam.DateCreated = DateTime.Now;
        newTeam.TeamName = team.TeamName;
        await _context.Teams.AddAsync(newTeam);
        await _context.SaveChangesAsync();
        return Ok(await GetTeams());
    }

    [HttpPut("addTeamMember")]
    public async Task<IActionResult> AddTeamMember(int teamId, int employeeId)
    {
        var employeeToAdd = await _context.Employees
            .FirstOrDefaultAsync(t => t.Id == employeeId);
        if (employeeToAdd == null) return NotFound("An employee with that ID does not exist");
        if (employeeToAdd.TeamId != null) return BadRequest("This employee already has a team");
        var team = await _context.Teams
            .FirstOrDefaultAsync(t => t.TeamId == teamId);
        if (team == null) return NotFound("A team with that ID does not exist");
        employeeToAdd.TeamId = team.TeamId;
        var teamMember = new TeamMember
        {
            EmployeeId = employeeId,
            TeamId = teamId,
            FirstName = employeeToAdd.FirstName,
            LastName = employeeToAdd.LastName,
            FromDate = DateTime.Now,
            IsActive = true
        };
        await _context.TeamMembers.AddAsync(teamMember);
        await _context.SaveChangesAsync();
        return Ok(await GetTeam(teamId));
    }

    [HttpPut("removeTeamMember")]
    public async Task<IActionResult> RemoveTeamMember(int teamId, int employeeId)
    {
        var employeeToRemove = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == employeeId);
        if (employeeToRemove == null) return NotFound("This employee does not exist");
        var employeeTeamMember = await _context.TeamMembers
            .FirstOrDefaultAsync(tm => tm.EmployeeId == employeeId && tm.TeamId == teamId && tm.IsActive);
        if (employeeTeamMember == null) return NotFound("This employee does not currently belong to that team or either of them does not exist");
        if (employeeToRemove.Role == Role.Teamlead)
        {
            var team = await _context.Teams
                .FirstOrDefaultAsync(t => t.TeamId == teamId);
            if (team.TeamLeaderId == employeeId)
            {
                team.TeamLeaderId = null;
            }
        }
        employeeTeamMember.ToDate = DateTime.Now;
        employeeTeamMember.IsActive = false;
        employeeToRemove.TeamId = null;
        await _context.SaveChangesAsync();
        return Ok(await GetTeamMembers(teamId));
    }

    [HttpPut("setTl")]
    public async Task<IActionResult> SetTeamLeader(int teamId, int teamLeaderId)
    {
        // Retrieve new and old team leaders and teams, validate data
        var team = await _context.Teams
            .FirstOrDefaultAsync(t => t.TeamId == teamId);
        if (team == null) return NotFound("A team with that ID does not exist");
        var employeeTl = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == teamLeaderId);
        if (employeeTl == null) return NotFound("A team leader with that ID does not exist");
        if (employeeTl.Role != Role.Teamlead) return BadRequest("This employee is not a team leader");
        var employeeTlCurrentTeam = await _context.Teams
            .FirstOrDefaultAsync(ct => ct.TeamId == employeeTl.TeamId);
        var employeeOldTl = await _context.Employees
            .FirstOrDefaultAsync(tl => tl.Id == team.TeamLeaderId);
        // Modify old and new TL link table records. Add new TL link
        if (employeeTlCurrentTeam != null) employeeTlCurrentTeam.TeamLeaderId = null;
        if (employeeOldTl != null)
        {
            employeeOldTl.TeamId = null;
            var teamMemberOldTl = await _context.TeamMembers
                .FirstOrDefaultAsync(tm => tm.EmployeeId == employeeOldTl.Id && tm.TeamId == teamId && tm.IsActive);
            if (teamMemberOldTl != null)
            {
                teamMemberOldTl.ToDate = DateTime.Now;
                teamMemberOldTl.IsActive = false;
            }
        }
        team.TeamLeaderId = employeeTl.Id;
        employeeTl.TeamId = teamId;
        var teamMemberNewTl = await _context.TeamMembers
            .FirstOrDefaultAsync(tm => tm.EmployeeId == teamLeaderId && tm.IsActive);
        if (teamMemberNewTl != null)
        {
            teamMemberNewTl.ToDate = DateTime.Now;
            teamMemberNewTl.IsActive = false;
        }
        var teamMember = new TeamMember
        {
            EmployeeId = teamLeaderId,
            TeamId = teamId,
            FirstName = employeeTl.FirstName,
            LastName = employeeTl.LastName,
            FromDate = DateTime.Now,
            IsActive = true
        };
        await _context.TeamMembers.AddAsync(teamMember);
        await _context.SaveChangesAsync();
        return Ok(await GetTeam(teamId));
    }

    [HttpDelete("deleteTeam/{id}")]
    public async Task<IActionResult> DeleteTeam(int id)
    {
        var teamToDelete = await _context.Teams
            .FirstOrDefaultAsync(t => t.TeamId == id);
        if (teamToDelete == null) return NotFound("A team with that ID was not found");
        var members = await _context.TeamMembers
            .FirstOrDefaultAsync(tm => tm.TeamId == id && tm.IsActive);
        if (members != null) return BadRequest("This team still has members");
        _context.Teams.Remove(teamToDelete);
        await _context.SaveChangesAsync();
        return Ok(await GetTeams());
    }
}