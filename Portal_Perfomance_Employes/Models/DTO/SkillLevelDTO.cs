using System.ComponentModel.DataAnnotations;

namespace PortalPerfomanceEmployees.Models
{
    public class SkillLevelDTO
    {
        [Required(ErrorMessage = "Please provide a skill ID to link the skill level to")]
        public int SkillLevelTypeId { get; set; }
        [Required(ErrorMessage = "Please give the skill level a name")]
        public string SkillLevelName { get; set; }
    }
}