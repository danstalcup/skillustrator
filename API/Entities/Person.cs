using System.Collections.Generic;

namespace Skillustrator.Api.Entities
{
    public class Person : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Skill> Skills { get; set; }
    }
}