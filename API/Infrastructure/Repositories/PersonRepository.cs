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
            return await _context.Set<Person>()
                .Include(x=> x.Skills)
                    .ThenInclude(x=> x.Skill)
                .FirstOrDefaultAsync(x=> x.Id == personId);
        }
    }
}