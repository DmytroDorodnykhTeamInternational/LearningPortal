using PortalPerfomanceEmployees.Models;
using PortalPerfomanceEmployees.Data;

namespace PortalPerfomanceEmployees.Repository
{
    public class SkillLevelRepository
    {
        private readonly AppDbContext _context;

        public SkillLevelRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<SkillLevel> GetSkillsByTypeId(int id)
        {
            return _context.SkillLevels.Where(sl => sl.SkillLevelTypeId == id).ToList();
        }

        public SkillLevel GetById(int id)
        {
            return _context.SkillLevels.FirstOrDefault(s => s.SkillLevelId == id);
        }
    }
}
