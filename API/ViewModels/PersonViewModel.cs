using System.Collections.Generic;
using Skillustrator.Api.Entities;

public class PersonViewModel {
    public ICollection<Skill> Skills { get; set; }

    public int Id { get; set; }

    public string LastName { get; set; }
    public string FirstName { get; set; }

}