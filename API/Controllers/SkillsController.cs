using System.Collections.Generic;
using Skillustrator.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Skillustrator.Api.Infrastructure;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using Skillustrator.Api.Infrastructure.Repositories;

namespace Skillustrator.Api.Controllers
{
    [Route("/api/[controller]")]
    public class SkillsController : Controller
    {
        private readonly IRepository<Tag> _tagRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly ILogger<SkillsController> _logger; 

        public SkillsController(ISkillRepository skillRepository, ILogger<SkillsController> logger, IRepository<Tag> tagRepository)
        {
            _skillRepository = skillRepository;
            _logger = logger;
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Skill>> Get([FromQuery] string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                return await _skillRepository.GetAllSkillsWithTags();
            }
            else {
                return await _skillRepository.GetAllSkillsByTag(tag);
            }
        } 

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var skill = await _skillRepository.GetSkillWithTags(id);
            if (skill == null)
            {
                return NotFound(); // This makes it return 404; otherwise it will return a 204 (no content) 
            }

            return new ObjectResult(skill);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Skill skill)
        {
            _logger.LogDebug("Starting save");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newSkill = new Skill { 
                Name = skill.Name
            };

            _skillRepository.Add(newSkill);
            await _skillRepository.SaveChangesAsync();

            _logger.LogDebug("Finished save");

            return CreatedAtAction(nameof(Get), new { id = newSkill.Id }, newSkill);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogDebug("Starting delete");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skill = _skillRepository.GetSingle(id);
            _skillRepository.Delete(skill);
            await _skillRepository.SaveChangesAsync();

            _logger.LogDebug("Finished delete");

            return new NoContentResult();
        }

       [HttpPost("{skillId:int}/addtag")]
        public async Task<IActionResult> AddTag(int git , [FromBody]SkillTagViewModel skillTagViewModel)
        {
            if (skillTagViewModel == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skill = await _skillRepository.GetSkillWithTags(skillTagViewModel.SkillId);

            if (skill == null) 
            {
                return NotFound();
            }

            var tagToAdd = await _tagRepository.GetSingleAsync(skillTagViewModel.TagId);
            
            var skillTag = new SkillTag 
            { 
                Skill = skill,
                Tag = tagToAdd
            };

            if (skill.Tags == null) 
            {
                skill.Tags = new Collection<SkillTag>();
            }
            skill.Tags.Add(skillTag);

            await _skillRepository.SaveChangesAsync();

            var skillViewModel = SkillViewModelFactory.Build(skill);

            return CreatedAtAction(nameof(Get), new { id = skillViewModel.Name }, skillViewModel);
        }

    }
}