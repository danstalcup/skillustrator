using System.Collections.Generic;

namespace ConsoleApplication.Entities
{
    public class Person : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Skill> Skills { get; set; }
    }
}