using Skillustrator.Api.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Skillustrator.Api.Infrastructure
{
    public interface ISkillRepository : IRepository<Skill> {
        Task<IEnumerable<Skill>> GetAllSkillsWithTags();
        Task<IEnumerable<Skill>> GetAllSkillsByTag(string tagName); 
        Task<Skill> GetSkillWithTags(int skillId);
     }
}