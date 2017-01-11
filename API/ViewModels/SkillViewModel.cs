using System.Collections.Generic;
using Skillustrator.Api.Entities;

public class SkillViewModel
{      
      public int Id { get; set; }
      
      public string Name { get; set; }

      public ICollection<SkillTag> Tags { get; set; }

      public SkillLevel SkillLevel { get; set; }

      public TimePeriod TimeUsed { get; set; }

      public TimePeriod TimeLastUsed { get; set; }
}