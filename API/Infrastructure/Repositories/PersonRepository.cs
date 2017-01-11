using System.Linq;
using Skillustrator.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Skillustrator.Api.Infrastructure.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        private SkillustratorContext _context;
        public PersonRepository(SkillustratorContext context)
            : base(context)
        { 
            _context = context;
        }

        public async Task<Person> GetPersonWithSkills(int personId) 
        {
            var person = await _context.Set<Person>()
                .Include(p=> p.Skills).ThenInclude(personSkills=> personSkills.Skill)
                .Include(p=> p.Skills).ThenInclude(personSkills=> personSkills.TimeUsed)
                    //.ThenInclude(t=> t.Description)
                .Include(p=> p.Skills).ThenInclude(personSkills=> personSkills.TimeSinceUsed)
                    //.ThenInclude(t=> t.Description)
                .Include(p=> p.Skills).ThenInclude(personSkills=> personSkills.SkillLevel)
                    //.ThenInclude(t=> t.Description)
                .FirstOrDefaultAsync(x=> x.Id == personId);

            return person;
        }
    }
}