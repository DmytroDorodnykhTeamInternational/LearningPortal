using System.ComponentModel.DataAnnotations;

namespace PortalPerfomanceEmployees.Models
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Please enter user name")]
        public string Username { get; set; } = "";
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; } = "";
    }
}
