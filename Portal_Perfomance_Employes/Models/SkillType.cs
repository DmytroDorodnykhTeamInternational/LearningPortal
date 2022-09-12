
using System.ComponentModel.DataAnnotations;

namespace PortalPerfomanceEmployees.Models
{
    public class SkillType
    {
        [Key]
        public int SkillTypeId { get; set; }
        public string SkillTypeName { get; set; }
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
    }
}
