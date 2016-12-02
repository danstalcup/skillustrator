namespace Skillustrator.Api.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Skill> Skills { get; set; }
    }
}