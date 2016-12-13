using System.Collections.Generic;
using Skillustrator.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Skillustrator.Api.Infrastructure;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace Skillustrator.Api.Controllers
{
    [Route("/api/[controller]")]
    public class SkillsController : Controller
    {
        private readonly IRepository<Skill> _skillRepository;
        private readonly ILogger<SkillsController> _logger; 

        public SkillsController(IRepository<Skill> skillRepository, ILogger<SkillsController> logger)
        {
            _skillRepository = skillRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Skill>> Get() => await _skillRepository.GetAllAsync();

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var skill = await _skillRepository.GetSingleAsync(id);
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

            return CreatedAtAction(nameof(Get), new { id = skill.Name }, skill);
        }
    }
}