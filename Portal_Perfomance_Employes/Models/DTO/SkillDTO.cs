using System.ComponentModel.DataAnnotations.Schema;

namespace PortalPerfomanceEmployees.Models
{
    public class SkillDTO
    {
        [ForeignKey("SkillLevelTypeId")]
        public int SkillLevelTypeId { get; set; }
        [ForeignKey("SkillTypeId")]
        public int SkillTypeId { get; set; }
        public string SkillName { get; set; }
    }
}