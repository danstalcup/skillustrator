namespace Skillustrator.Api.Entities
{
    public class PersonSkill : EntityBase
    {
        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        public int SkillLevel { get; set; }

        public int TimeUsedTicks { get; set; }

        [NotMapped]
        public int TimeUsed
        {
            get
            {
                return new TimeSpan
            }
        }
    }
}