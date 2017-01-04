using System.Collections.Generic;

public class PersonViewModel {
    
    public ICollection<SkillViewModel> Skills { get; set; }

    public int Id { get; set; }

    public string LastName { get; set; }
    
    public string FirstName { get; set; }

}