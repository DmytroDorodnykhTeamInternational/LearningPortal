using PortalPerfomanceEmployees.Models;
using PortalPerfomanceEmployees.Data;

namespace PortalPerfomanceEmployees.Repository
{
    public class TeamRepository
    {
        private readonly AppDbContext _context;

        public TeamRepository(AppDbContext context)
        {
            _context = context;
        }

        public Team GetTeamById(int id)
        {
            return _context.Teams.FirstOrDefault(t => t.TeamId == id);
        }
    }
}
