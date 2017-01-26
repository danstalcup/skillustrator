using System.Collections.ObjectModel;
using Skillustrator.Api.Entities;
using Skillustrator.ViewModels;
using Skillustrator.ViewModels.Write;

namespace Skillustrator.ViewModels.Factories
{
    public class PersonViewModelFactory
    {
        public static PersonViewModel Build(Person person)
        {
            var skillViewModels = new Collection<SkillViewModel>();

            foreach (var personSkill in person.Skills) {
                skillViewModels.Add(new SkillViewModel
                {
                    Id = personSkill.Id,
                    Name = personSkill.Skill.Name,
                    Tags = personSkill.Skill.Tags,
                    SkillLevel = personSkill?.SkillLevel,
                    TimeUsed = personSkill?.TimeUsed, 
                    TimeLastUsed = personSkill?.TimeSinceUsed 
                });
            }

            var personViewModel = new PersonViewModel {
                Id = person.Id, 
                LastName = person.LastName,
                FirstName = person.FirstName,
                Skills = skillViewModels
            };

            return personViewModel;
        }
    }
}