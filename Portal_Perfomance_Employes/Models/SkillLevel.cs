using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalPerfomanceEmployees.Models
{
    public class SkillLevel
    {
        [Key]
        public int SkillLevelId { get; set; }
        [ForeignKey("SkillLevelTypeId")]
        public int SkillLevelTypeId { get; set; }
        public SkillLevelType SkillLevelType { get; set; }
        public string SkillLevelName { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; } = new List<EmployeeSkill>();
    }
}
