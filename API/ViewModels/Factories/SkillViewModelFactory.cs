using System.Collections.ObjectModel;
using Skillustrator.Api.Entities;
using Skillustrator.ViewModels;
using Skillustrator.ViewModels.Write;

namespace Skillustrator.ViewModels.Factories
{
    public class SkillViewModelFactory
    {
        public static SkillViewModel Build(Skill skill)
        {
            var tagViewModels = new Collection<TagViewModel>();

            foreach (var skillTag in skill.Tags) {
                tagViewModels.Add(new TagViewModel
                {
                    Id = skillTag.Id,
                    Name = skillTag.Tag.Name                   
                });
            }

            var skillViewModel = new SkillViewModel {
                Id = skill.Id, 
                Name = skill.Name,
                Tags = tagViewModels
            };

            return skillViewModel;
        }
    }
}