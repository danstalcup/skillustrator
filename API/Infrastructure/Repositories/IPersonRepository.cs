using Skillustrator.Api.Entities;
using System.Threading.Tasks;

namespace Skillustrator.Api.Infrastructure
{
    public interface IPersonRepository : IRepository<Person> {
        Task<Person> GetPersonWithSkills(int personId);
     }
}