using System.Collections.Generic;
using Skillustrator.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Skillustrator.Api.Infrastructure;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Skillustrator.Api.Controllers
{
    [Route("/api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly ILogger<PersonController> _logger; 

        public PersonController(IPersonRepository personRepository, ILogger<PersonController> logger)
        {
            _personRepository = personRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> Get() => await _personRepository.GetAllAsync();

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await _personRepository.GetSingleAsync(id);
            if (person == null)
            {
                return NotFound(); // This makes it return 404; otherwise it will return a 204 (no content) 
            }

            return new ObjectResult(person);
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

            _personRepository.Add(new Person { 
                LastName = person.LastName,
                FirstName = person.FirstName });
            await _personRepository.SaveChangesAsync();

            _logger.LogDebug("Finished save");

            return CreatedAtAction(nameof(Get), new { id = person.LastName }, person);
        }
    }
}