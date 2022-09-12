using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalPerfomanceEmployees.Models
{
    public class EmployeeCertification
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CertificationId")]
        public int CertificationId { get; set; }
        public Certification Certification { get; set; }
        [ForeignKey("Id")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCertificate { get; set; }
        public string CertifcateUrl { get; set; }
    }
}
