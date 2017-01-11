using System.Linq;
using Skillustrator.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Skillustrator.Api.Infrastructure.Repositories
{
    public class SkillsMetadataRepository : BaseRepository<LookupBase>, ISkillsMetadataRepository
    {
        private SkillustratorContext _context;
        public SkillsMetadataRepository(SkillustratorContext context)
            : base(context)
        { 
            _context = context;
        }

        public async Task<SkillsMetadata> Get() 
        {
            var skillLevels = await _context.Set<SkillLevel>().ToListAsync();

            var timePeriods = await _context.Set<TimePeriod>().ToListAsync();

            var skillsMetadata = new SkillsMetadata 
            {
                SkillLevels = skillLevels, 
                TimePeriods = timePeriods
            };

            return skillsMetadata;
        }
    }
}

public class SkillsMetadata 
{
    public ICollection<SkillLevel> SkillLevels { get; set; }
    public ICollection<TimePeriod> TimePeriods { get; set; }
}
