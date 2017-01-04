using System.Collections.Generic;
using Skillustrator.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Skillustrator.Api.Infrastructure;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Linq;

namespace Skillustrator.Api.Controllers
{
    [Route("/api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        private readonly IRepository<Skill> _skillRepository;
        private readonly ILogger<PersonController> _logger; 

        public PersonController(IPersonRepository personRepository, IRepository<Skill> skillRepository, ILogger<PersonController> logger)
        {
            _personRepository = personRepository;
            _skillRepository = skillRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> Get() => await _personRepository.GetAllAsync();

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await _personRepository.GetPersonWithSkills(id);

            if (person == null)
            {
                return NotFound(); // This makes it return 404; otherwise it will return a 204 (no content) 
            }

            var skills = new Collection<Skill>();
            var skillViewModels = new Collection<SkillViewModel>();

            foreach (var personSkill in person.Skills) {
                skills.Add(personSkill.Skill);
                skillViewModels.Add(new SkillViewModel
                {
                    Name = personSkill.Skill.Name,
                    Tags = personSkill.Skill.Tags
                });
            }

            var personViewModel = new PersonViewModel {
                Id = id, 
                LastName = person.LastName,
                FirstName = person.FirstName,
                Skills = skillViewModels
            };

            return new ObjectResult(personViewModel);
        }

        // TEST: curl -H "Content-Type: application/json" -X POST -d '{"lastname":"Posted"}' http://localhost:5000/api/applicant 
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Person person)
        {
            _logger.LogDebug("Starting save");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jsSkill = new Skill 
            { 
                Name = "Test Skill 1"
            };

            var personSkill = new PersonSkill 
            {
                Skill = jsSkill
            };

            _personRepository.Add(new Person { 
                LastName = person.LastName,
                FirstName = person.FirstName,
                Skills = new Collection<PersonSkill> {
                    personSkill
                }    
            });

            await _personRepository.SaveChangesAsync();

            _logger.LogDebug("Finished save");

            return CreatedAtAction(nameof(Get), new { id = person.LastName }, person);
        }

        [HttpGet("{personId:int}/addskill/{skillId:int}")]
        public async Task<IActionResult> AddSkill(int personId, int skillId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _personRepository.GetPersonWithSkills(personId);

            if (person == null) 
            {
                return NotFound();
            }

            var skillToAdd = await _skillRepository.GetSingleAsync(skillId);
            var personSkill = new PersonSkill 
            { 
                Skill = skillToAdd,
                Person = person 
            };

            if (person.Skills == null) 
            {
                person.Skills = new Collection<PersonSkill>();
            }
            person.Skills.Add(personSkill);

            await _personRepository.SaveChangesAsync();

            var personViewModel = new PersonViewModel {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Skills = new Collection<SkillViewModel>()
            };

            foreach(var skill in person.Skills) 
            {
                var skillViewModel = new SkillViewModel 
                {
                    Name = skill.Skill.Name,
                    Tags = skill.Skill.Tags
                };
                personViewModel.Skills.Add(skillViewModel);
            }

            return CreatedAtAction(nameof(Get), new { id = personViewModel.LastName }, personViewModel);
        }
    }
}