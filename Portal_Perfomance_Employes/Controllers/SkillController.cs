using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalPerfomanceEmployees.Data;
using PortalPerfomanceEmployees.Models;

namespace PortalPerfomanceEmployees.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class SkillController : Controller
{
    private readonly AppDbContext _context;
    public SkillController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{skillId}")]
    public async Task<IActionResult> GetSkill(int skillId)
    {
        var skill = await _context.Skills.FirstOrDefaultAsync(s => s.SkillId == skillId);
        return skill != null ? Ok(skill) : NotFound("This skill does not exist");
    }

    [HttpGet]
    public async Task<IActionResult> GetSkills()
    {
        return Ok(await _context.Skills.ToListAsync());
    }

    [HttpGet("getSkillLevels")]
    public async Task<IActionResult> GetSkillLevels(int skillId)
    {
        var skill = await _context.Skills
            .FirstOrDefaultAsync(s => s.SkillId == skillId);
        if (skill == null) return NotFound("This skill does not exist");
        var skillLevelType = await _context.SkillLevelTypes
            .FirstOrDefaultAsync(sl => sl.SkillLevelTypeId == skill.SkillLevelTypeId);
        if (skillLevelType == null) return NotFound("This skill does not have skill levels associated with it");
        var skillLevels = await _context.SkillLevels
            .Where(sl => sl.SkillLevelTypeId == skillLevelType.SkillLevelTypeId)
            .ToListAsync();
        var skillLevelsList = new List<SkillLevelDTO>();
        foreach (var skillLevel in skillLevels)
        {
            skillLevelsList.Add(new SkillLevelDTO
            {
                SkillLevelName = skillLevel.SkillLevelName,
                SkillLevelTypeId = skillLevel.SkillLevelTypeId
            });
        }
        return Ok(skillLevelsList);
    }

    [HttpGet("/getEmployeeSkills/{employeeId}")]
    public async Task<IActionResult> GetEmployeeSkills(int employeeId)
    {
        var emp = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == employeeId);
        if (emp == null) return NotFound("This employee does not exist");
        var empSkills = await _context.EmployeeSkills
            .Where(es => es.EmployeeId == employeeId).ToListAsync();
        if (empSkills.Count == 0) return Ok("This employee does not have any skills added");
        var skillDtos = new List<SkillDTO>();
        foreach (var empSkill in empSkills)
        {
            var skill = await _context.Skills.FirstOrDefaultAsync(s => s.SkillId == empSkill.SkillId);
            if (skill != null)
            {
                skillDtos.Add(new SkillDTO
                {
                    SkillLevelTypeId = skill.SkillLevelTypeId,
                    SkillName = skill.SkillName
                });
            }
        }
        return Ok(skillDtos.ToList());
    }

    [HttpPost("createSkill")]
    public async Task<IActionResult> CreateSkill(SkillDTO skill)
    {
        if (await _context.SkillLevelTypes
            .FirstOrDefaultAsync(slt => slt.SkillLevelTypeId == skill.SkillLevelTypeId) == null) return NotFound("This skill level types does not exist");
        if (await _context.SkillTypes
            .FirstOrDefaultAsync(st => st.SkillTypeId == skill.SkillTypeId) == null) return NotFound("This skill type does not exist");
        var newSkill = new Skill
        {
            SkillLevelTypeId = skill.SkillLevelTypeId,
            SkillName = skill.SkillName,
            SkillTypeId = skill.SkillTypeId
        };
        await _context.Skills.AddAsync(newSkill);
        await _context.SaveChangesAsync();
        return Ok(await GetSkills());
    }

    [HttpPost("createSkillLevel")]
    public async Task<IActionResult> CreateSkillLevel(SkillLevelDTO skillLevel)
    {
        if (await _context.SkillLevelTypes
            .FirstOrDefaultAsync(slt => slt.SkillLevelTypeId == skillLevel.SkillLevelTypeId) == null) return NotFound("You must provide a valid skill type ID");
        var existingSkill = await _context.SkillLevels.FirstOrDefaultAsync(sl => sl.SkillLevelTypeId == skillLevel.SkillLevelTypeId && sl.SkillLevelName == skillLevel.SkillLevelName);
        if (existingSkill != null) return BadRequest("This skill level already exists");
        var newSkillLevel = new SkillLevel
        {
            SkillLevelName = skillLevel.SkillLevelName,
            SkillLevelTypeId = skillLevel.SkillLevelTypeId
        };
        await _context.SkillLevels.AddAsync(newSkillLevel);
        await _context.SaveChangesAsync();
        return Ok(newSkillLevel);
    }

    [HttpPost("createSkillLevelType")]
    public async Task<IActionResult> CreateSkillLevelType(string skillLevelTypeName)
    {
        var skillLevelType = await _context.SkillLevelTypes
            .FirstOrDefaultAsync(slt => slt.SkillLevelTypeName == skillLevelTypeName);
        if (skillLevelType != null) return BadRequest("This skill level type already exists");
        var newSkillLevelType = new SkillLevelType
        {
            SkillLevelTypeName = skillLevelTypeName
        };
        await _context.SkillLevelTypes.AddAsync(newSkillLevelType);
        await _context.SaveChangesAsync();
        return Ok(newSkillLevelType);
    }

    [HttpPost("grantSkill")]
    public async Task<IActionResult> GrantSkill(int skillId, int employeeId, int skillLevelId)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == employeeId);
        if (employee == null) return NotFound("This employee does not exist");
        var skill = await _context.Skills
            .FirstOrDefaultAsync(s => s.SkillId == skillId);
        if (skill == null) return NotFound("This skill does not exist");
        var skillLevelType = await _context.SkillLevelTypes.FirstOrDefaultAsync(sl => sl.SkillLevelTypeId == skill.SkillLevelTypeId);
        if (skillLevelType == null) return BadRequest("This skill does not have a skill level associated with it");
        var employeeSkill = await _context.EmployeeSkills.FirstOrDefaultAsync(s => s.SkillId == skillId && s.EmployeeId == employeeId);
        if (employeeSkill != null)
        {
            employeeSkill.SkillLevelId = skillLevelId;
            return Ok(employee);
        }
        var newSkill = new EmployeeSkill
        {
            EmployeeId = employeeId,
            SkillId = skillId,
            SkillLevelId = skillLevelId
        };
        await _context.EmployeeSkills.AddAsync(newSkill);
        await _context.SaveChangesAsync();
        return Ok(employee);
    }
}
