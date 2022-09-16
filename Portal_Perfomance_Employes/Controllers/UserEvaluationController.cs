// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalPerfomanceEmployees.Data;
using PortalPerfomanceEmployees.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Data;
using NuGet.Protocol;

namespace PortalPerfomanceEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserEvaluationController : Controller
    {
        private readonly AppDbContext _context;

        public UserEvaluationController(AppDbContext context)
        {
            _context = context;
        }

        [Route("GetSkillTypes")]
        [HttpGet]
        public async Task<IActionResult> GetSkillTypes()
        {
            return Ok(await _context.SkillTypes.ToListAsync());
        }

        [Route("GetSkillLevelTypes")]
        [HttpGet]
        public async Task<IActionResult> GetSkillLevelTypes()
        {
            return Ok(await _context.SkillLevelTypes.ToListAsync());
        }

        [Route("GetSkillLevels")]
        [HttpGet]
        public async Task<IActionResult> GetSkillLevels(int skillLevelTypeId)
        {
            var skillLevels = await _context.SkillLevels.Where(sl => sl.SkillLevelTypeId == skillLevelTypeId).ToListAsync();
            return (skillLevels == null) ? NotFound("Skill level list is empty for this level type") : Ok(skillLevels);
        }

        [Route("GetUserSoftSkills")]
        [HttpGet]
        public async Task<IActionResult> GetUserSoftSkills()
        {
            if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var empSkills = await _context.EmployeeSkills.Where(e => e.EmployeeId == id).ToListAsync();
                if (empSkills != null)
                {
                    var result = BuildSkillsTable(empSkills, "Soft Skill").Result;
                    return Ok(result);
                }
                return NotFound("The user skills list is empty");
            }
            return StatusCode(403, "Error! Token is corrupt. ID of authorized user was not found");
        }

        [Route("GetUserHardSkills")]
        [HttpGet]
        public async Task<IActionResult> GetUserHardSkills()
        {
            if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var empSkills = await _context.EmployeeSkills.Where(e => e.EmployeeId == id).ToListAsync();
                if (empSkills != null)
                {
                    var result = BuildSkillsTable(empSkills, "Hard Skill").Result;
                    return Ok(result);
                }
                return NotFound("The user skills list is empty");
            }
            return StatusCode(403, "Error! Token is corrupt. ID of authorized user was not found");
        }

        [Route("AddUserSkill")]
        [HttpPut]
        public async Task<IActionResult> AddUserSkill(int skillType, string skillName, int skillLevelId, int skillLevelTypeId)
        {
            if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var emp = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
                if (emp != null)
                {
                    Skill newSkill = new Skill();
                    newSkill.SkillLevelTypeId = skillLevelTypeId;
                    newSkill.SkillTypeId = skillType;
                    newSkill.SkillName = skillName;
                    _context.Skills.Add(newSkill);
                    await _context.SaveChangesAsync();

                    var newSkillId = _context.Skills.OrderByDescending(skill => skill.SkillId).FirstOrDefault().SkillId;

                    EmployeeSkill newEmployeeSkill = new EmployeeSkill();
                    newEmployeeSkill.EmployeeId = emp.Id;
                    newEmployeeSkill.SkillId = newSkillId;
                    newEmployeeSkill.SkillLevelId = skillLevelId;
                    _context.EmployeeSkills.Add(newEmployeeSkill);
                    await _context.SaveChangesAsync();

                    return Ok("Tables have been successfully updated");
                }
            }
            return StatusCode(403, "Error! Token is corrupt. ID of authorized user was not found");
        }

        private async Task<string> BuildSkillsTable(List<EmployeeSkill> empSkills, string skillTypeName)
        {
            var hardSkillsTable = new DataTable();
            hardSkillsTable.Columns.Add("SkillName", typeof(string));
            hardSkillsTable.Columns.Add("SkillLevel", typeof(string));

            foreach (var empSkill in empSkills)
            {
                var skill = await _context.Skills.FirstOrDefaultAsync(s => s.SkillId == empSkill.SkillId);
                var skillType = await _context.SkillTypes.FirstOrDefaultAsync(st => st.SkillTypeId == skill.SkillTypeId);
                var skillLevel = await _context.SkillLevels.FirstOrDefaultAsync(sl => sl.SkillLevelId == empSkill.SkillLevelId);

                if (skillType.SkillTypeName == skillTypeName)
                {
                    hardSkillsTable.Rows.Add(
                        skill.SkillName,
                        skillLevel.SkillLevelName
                    );
                }
            }
            return hardSkillsTable.ToJson();
        }
    }
}
