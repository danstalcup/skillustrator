using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skillustrator.Api.Entities
{
    public class PersonSkill : EntityBase
    {
        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        public SkillLevel SkillLevel { get; set; }

        public TimePeriod TimeUsed { get; set; }

        public TimePeriod TimeSinceUsed { get; set; }
    }
}