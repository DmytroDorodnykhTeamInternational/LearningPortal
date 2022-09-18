using System.ComponentModel.DataAnnotations;

namespace PortalPerfomanceEmployees.Models
{
    public class CertificationSkill
    {
        [Key]
        public int CertificationSkillId { get; set; }
        public int CertificationId { get; set; }
        public int SkillId { get; set; }

    }
}