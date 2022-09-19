using PortalPerfomanceEmployees.Models;
using PortalPerfomanceEmployees.Data;

namespace PortalPerfomanceEmployees.Repository
{
    public class TeamMemberRespository
    {
        private readonly AppDbContext _context;

        public TeamMemberRespository(AppDbContext context)
        {
            _context = context;
        }

        public TeamMember TeamMemberActive(int id)
        {
            return _context.TeamMembers.FirstOrDefault(e => e.Id == id && e.IsActive);
        }

        public List<TeamMember> TeamActive(int id)
        {
            return _context.TeamMembers.Where(e => e.TeamId == id && e.IsActive).ToList();
        }

        public List<TeamMember> GetListTeamMember(int id)
        {
            return _context.TeamMembers.Where(e => e.EmployeeId == id).ToList();
        }

    }
}
