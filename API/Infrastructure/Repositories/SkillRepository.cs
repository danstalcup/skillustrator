using System.Linq;
using Skillustrator.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Skillustrator.Api.Infrastructure.Repositories
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        private SkillustratorContext _context;

        public SkillRepository(SkillustratorContext context)
            : base(context)
        { 
            _context = context;
        }

        public async Task<IEnumerable<Skill>> GetAllSkillsWithTags() 
        {
            var skills = _context.Set<Skill>()
                .Include(s => s.Tags)
                    .ThenInclude(skillTag => skillTag.Tag);

            return await skills.ToListAsync();
        }

        public async Task<IEnumerable<Skill>> GetAllSkillsByTag(string tag) 
        {
            var skills = _context.Set<Skill>()
                .Where(s => s.Tags.Any(t => t.Tag.Name == tag))
                .Include(s => s.Tags)
                    .ThenInclude(skillTag => skillTag.Tag);

            return await skills.ToListAsync();
        }

        public async Task<Skill> GetSkillWithTags(int skillId) 
        {
            var skill = await _context.Set<Skill>()
                .Include(s => s.Tags).ThenInclude(t=> t.Tag)
                .FirstOrDefaultAsync(s => s.Id == skillId);

            return skill;
        }
    }
}