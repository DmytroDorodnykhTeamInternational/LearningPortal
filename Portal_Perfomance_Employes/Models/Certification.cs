using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalPerfomanceEmployees.Models
{
    public class Certification
    {
        [Key]
        public int CertificationId { get; set; }
        [ForeignKey("SkillId")]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public string CertificationName { get; set; }
        public ICollection<EmployeeCertification> EmployeeCertifications { get; set; } = new List<EmployeeCertification>();
    }
}
