using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalPerfomanceEmployees.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public string Password { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public Seniority Seniority { get; set; }
        public Role Role { get; set; }
        [ForeignKey("TeamId")]
        public Nullable<int> TeamId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }
    }

    public enum Seniority
    {
        Junior, MidLevel, Senior
    }
    public enum Role
    {
        Employee, Teamlead, Admin
    }
}
