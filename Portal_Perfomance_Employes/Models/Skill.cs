using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalPerfomanceEmployees.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        [ForeignKey("SkillLevelTypeId")]
        public int SkillLevelTypeId { get; set; }
        public SkillLevelType SkillLevelType { get; set; }
        [ForeignKey("SkillTypeId")]
        public int SkillTypeId { get; set; }
        public SkillType SkillType { get; set; }
        public string SkillName { get; set; }
        public Certification Certification { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; } = new List<EmployeeSkill>();
    }
}
