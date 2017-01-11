using Skillustrator.Api.Entities;
using System.Threading.Tasks;

namespace Skillustrator.Api.Infrastructure
{
    public interface ISkillsMetadataRepository : IRepository<LookupBase> {
        Task<SkillsMetadata> Get();
     }
}