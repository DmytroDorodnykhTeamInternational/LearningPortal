
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalPerfomanceEmployees.Models
{
    public class EmployeeSkill
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [ForeignKey("SkillId")]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        [ForeignKey("SkillLevelId")]
        public int SkillLevelId { get; set; }
        public SkillLevel SkillLevel { get; set; }

    }
}
