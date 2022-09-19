using PortalPerfomanceEmployees.Models;
using PortalPerfomanceEmployees.Data;

namespace PortalPerfomanceEmployees.Repository
{
    public class SkillTypesRepository
    {
        private readonly AppDbContext _context;

        public SkillTypesRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<SkillType> GetAll()
        {
            return _context.SkillTypes.ToList();
        }

        public SkillType GetById(int id)
        {
            return _context.SkillTypes.FirstOrDefault(s => s.SkillTypeId == id);
        }
    }
}
