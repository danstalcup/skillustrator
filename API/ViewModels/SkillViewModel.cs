using System.Collections.Generic;
using Skillustrator.Api.Entities;

public class SkillViewModel
{      
      public string Name { get; set; }

      public ICollection<SkillTag> Tags { get; set; }

}