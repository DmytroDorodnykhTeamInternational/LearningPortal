using PortalPerfomanceEmployees.Models;
using PortalPerfomanceEmployees.Data;

namespace PortalPerfomanceEmployees.Repository
{
    public class SkillRepository
    {
        private readonly AppDbContext _context;

        public SkillRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Skill> GetAll()
        {
            return _context.Skills.ToList();
        }

        public Skill GetById(int id)
        {
            return _context.Skills.FirstOrDefault(s => s.SkillId == id);
        }

        public int Create(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return skill.SkillId;
        }
    }
}
