using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalPerfomanceEmployees.Models;

public class Team
{
    [Key]
    public int TeamId { get; set; }
    public DateTime DateCreated { get; set; }
    public string TeamName { get; set; }
    public Nullable<int> TeamLeaderId { get; set; }
    public ICollection<TeamMember> TeamMembers { get; set; }
}