using PortalPerfomanceEmployees.Repository;
using PortalPerfomanceEmployees.Models;
using NuGet.Protocol;
using System.Data;
using System.Security.Claims;

namespace PortalPerfomanceEmployees.Services
{
    public class UserEvaluationServices
    {
        private readonly SkillTypesRepository _skillTypesRepository;
        private readonly SkillLevelRepository _skillLevelRepository;
        private readonly SkillRepository _skillRepository;
        private readonly EmployeeSkillRepository _employeeSkillRepository;
        private readonly EmployeeRepository _employeeRepository;

        public UserEvaluationServices(
                SkillTypesRepository skillTypesRepository,
                SkillLevelRepository skillLevelRepository,
                SkillRepository skillRepository,
                EmployeeSkillRepository employeeSkillRepository,
                EmployeeRepository employeeRepository)
        {
            _skillRepository = skillRepository;
            _skillTypesRepository = skillTypesRepository;
            _skillLevelRepository = skillLevelRepository;
            _employeeSkillRepository = employeeSkillRepository;
            _employeeRepository = employeeRepository;
        }
        public List<SkillType> GetSkillTypes()
        {
            return _skillTypesRepository.GetAll();
        }

        public List<Skill> GetSkillLevelTypes()
        {
            return _skillRepository.GetAll();
        }

        public List<SkillLevel> GetSkillLevels(int skillLevelTypeId)
        {
            return _skillLevelRepository.GetSkillsByTypeId(skillLevelTypeId);
        }

        public string GetUserSoftSkills(ClaimsPrincipal user)
        {
            if (int.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var empSkills = _employeeSkillRepository.GetEmployeeSkillsOfEmployee(id);
                if (empSkills != null)
                {
                    var result = BuildSkillsTable(empSkills, "Soft Skill");
                    return result;
                }
                return "";
            }
            return "";
        }

        public string GetUserHardSkills(ClaimsPrincipal user)
        {
            if (int.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var empSkills = _employeeSkillRepository.GetEmployeeSkillsOfEmployee(id);
                if (empSkills != null)
                {
                    var result = BuildSkillsTable(empSkills, "Hard Skill");
                    return result;
                }
                return "";
            }
            return "";
        }

        public string AddUserSkill(ClaimsPrincipal user, int skillType, string skillName, int skillLevelId, int skillLevelTypeId)
        {
            if (int.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                var emp = _employeeRepository.GetById(id);
                if (emp != null)
                {
                    Skill newSkill = new Skill();
                    newSkill.SkillLevelTypeId = skillLevelTypeId;
                    newSkill.SkillTypeId = skillType;
                    newSkill.SkillName = skillName;

                    var newSkillId = _skillRepository.Create(newSkill);

                    EmployeeSkill newEmployeeSkill = new EmployeeSkill();
                    newEmployeeSkill.EmployeeId = emp.Id;
                    newEmployeeSkill.SkillId = newSkillId;
                    newEmployeeSkill.SkillLevelId = skillLevelId;
                    _employeeSkillRepository.Create(newEmployeeSkill);

                    return "Tables have been successfully updated";
                }
            }
            return "";
        }

        private string BuildSkillsTable(List<EmployeeSkill> empSkills, string skillTypeName)
        {
            var hardSkillsTable = new DataTable();
            hardSkillsTable.Columns.Add("SkillName", typeof(string));
            hardSkillsTable.Columns.Add("SkillLevel", typeof(string));

            foreach (var empSkill in empSkills)
            {
                var skill = _skillRepository.GetById(empSkill.SkillId);
                var skillType = _skillTypesRepository.GetById(skill.SkillTypeId);
                var skillLevel = _skillLevelRepository.GetById(empSkill.SkillLevelId);

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
