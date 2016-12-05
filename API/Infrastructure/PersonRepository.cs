using Skillustrator.Api.Entities;

namespace Skillustrator.Api.Infrastructure.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(SkillustratorContext context)
            : base(context)
        { }
    }
}