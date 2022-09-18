using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortalPerfomanceEmployees.Models
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Id")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [ForeignKey("TeamId")]
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}