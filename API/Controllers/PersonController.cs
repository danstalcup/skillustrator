using System.Collections.Generic;
using Skillustrator.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Skillustrator.Api.Infrastructure;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using Skillustrator.ViewModels.Write;
using Skillustrator.ViewModels.Factories;
using System.Linq;

namespace Skillustrator.Api.Controllers
{
    [Route("/api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        private readonly IRepository<Skill> _skillRepository;

        private readonly IRepository<PersonSkill> _personSkillRepository;

        private readonly ISkillsMetadataRepository _metadataRepository;
        private readonly ILogger<PersonController> _logger; 

        public PersonController(
            IPersonRepository personRepository, 
            IRepository<Skill> skillRepository,
            IRepository<PersonSkill> personSkillRepository,
            ILogger<PersonController> logger,
            ISkillsMetadataRepository metadataRepository)
        {
            _personRepository = personRepository;
            _skillRepository = skillRepository;
            _personSkillRepository = personSkillRepository;
            _metadataRepository = metadataRepository;
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

            var personViewModel = PersonViewModelFactory.Build(person);

            return new ObjectResult(personViewModel);
        }

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

        [HttpPost("{personId:int}/addskill")]
        public async Task<IActionResult> AddSkill(int git , [FromBody]PersonSkillViewModel personSkillViewModel)
        {
            if (personSkillViewModel == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _personRepository.GetPersonWithSkills(personSkillViewModel.PersonId);

            if (person == null) 
            {
                return NotFound();
            }

            var skillToAdd = await _skillRepository.GetSingleAsync(personSkillViewModel.SkillId);
            var skillsMetadata = await _metadataRepository.Get();
            var personSkill = new PersonSkill 
            { 
                Skill = skillToAdd,
                SkillLevel = skillsMetadata.SkillLevels.Where(x=> x.Code == personSkillViewModel.SkillLevelCode).FirstOrDefault(),
                TimeUsed = skillsMetadata.TimePeriods.Where(x=> x.Code == personSkillViewModel.TimeUsedCode).FirstOrDefault(),
                TimeSinceUsed = skillsMetadata.TimePeriods.Where(x=> x.Code == personSkillViewModel.TimeLastUsedCode).FirstOrDefault()
            };

            if (person.Skills == null) 
            {
                person.Skills = new Collection<PersonSkill>();
            }
            person.Skills.Add(personSkill);

            await _personRepository.SaveChangesAsync();

            var personViewModel = PersonViewModelFactory.Build(person);

            return CreatedAtAction(nameof(Get), new { id = personViewModel.LastName }, personViewModel);
        }

        [HttpDelete("{personId:int}/removeskill/{personSkillId:int}")]
        public async Task<IActionResult> RemoveSkill(int personId, int personSkillId)
        {
            var person = await _personRepository.GetPersonWithSkills(personId);

            if (person == null) 
            {
                return NotFound();
            }

            var skillToRemove = person.Skills.Where(x => x.Id == personSkillId).SingleOrDefault();
            if (skillToRemove != null)
            {
                person.Skills.Remove(skillToRemove);
                _personSkillRepository.Delete(skillToRemove);
                await _personSkillRepository.SaveChangesAsync();
                await _personRepository.SaveChangesAsync();
            }

            var personViewModel = PersonViewModelFactory.Build(person);   

            return new ObjectResult(personViewModel);        
        }
    }
}