using System.ComponentModel.DataAnnotations;

namespace PortalPerfomanceEmployees.Models
{
    public class TeamDTO
    {
        [Required(ErrorMessage = "Please enter a team name")]
        public string TeamName { get; set; }
    }
}