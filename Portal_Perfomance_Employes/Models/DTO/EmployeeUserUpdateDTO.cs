using System.ComponentModel.DataAnnotations;

namespace PortalPerfomanceEmployees.Models
{
    public class EmployeeUserUpdateDTO
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
    }
}