using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skillustrator.Api.Entities
{
    public class Organization : EntityBase
    {
        public string Name { get; set; }

        public ICollection<Person> People { get; set; }

    }
}
