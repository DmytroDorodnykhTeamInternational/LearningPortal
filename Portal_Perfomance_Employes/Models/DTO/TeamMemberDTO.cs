namespace PortalPerfomanceEmployees.Models
{
    public class TeamMemberDTO
    {
        public int EmployeeId { get; set; }
        public int TeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? FromDate { get; set; }
    }
}