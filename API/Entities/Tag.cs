using System.Collections.Generic;

namespace Skillustrator.Api.Entities
{
    public class Tag : EntityBase
    {
        public string Name { get; set; }

        public ICollection<SkillTag> Skills { get; set; }
    }
}
