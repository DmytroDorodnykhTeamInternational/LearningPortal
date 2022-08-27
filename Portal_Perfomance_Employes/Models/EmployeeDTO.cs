using System.ComponentModel.DataAnnotations;

namespace PortalPerfomanceEmployees.Models
{
    public class EmployeeDTO
    {
        [Required(ErrorMessage = "Please enter a user name")]
        public string Username { get; set; } = "";
        [Required(ErrorMessage = "Please enter a email")]
        [EmailAddress]
        public string EmailAddress { get; set; } = "";
        [Required(ErrorMessage = "Please enter a password")]
        [StringLength(255, ErrorMessage = "Must have at least 6 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
        [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName { get; set; } = "";
        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; } = "";
        [Required(ErrorMessage = "Please enter a date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please choose a seniority level")]
        [Range(0, 2, ErrorMessage = "Please choose a correct seniority level")]
        public Seniority? Seniority { get; set; }
        [Required(ErrorMessage = "Please choose a role tier")]
        [Range(0, 2, ErrorMessage = "Please choose a correct role tier")]
        public Role? Role { get; set; }
        [Required(ErrorMessage = "Please enter a group id")]
        public int TeamId { get; set; }
        // These fields are nullable because otherwise the [Required] attribute will not work
    }
}