using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skillustrator.Api.Entities
{
    public class SkillTag : EntityBase
    {
        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
