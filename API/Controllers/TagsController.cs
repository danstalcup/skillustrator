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
    public class TagsController : Controller
    {
        private readonly IRepository<Tag> _tagRepository;
        private readonly ILogger<TagsController> _logger; 

        public TagsController(IRepository<Tag> tagRepository, ILogger<TagsController> logger)
        {
            _tagRepository = tagRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Tag>> Get() => await _tagRepository.GetAllAsync();

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var tag = await _tagRepository.GetSingleAsync(id);
            if (tag == null)
            {
                return NotFound(); // This makes it return 404; otherwise it will return a 204 (no content) 
            }

            return new ObjectResult(tag);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Tag tag)
        {
            _logger.LogDebug("Starting save");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTag = new Tag { 
                Name = tag.Name
            };

            _tagRepository.Add(newTag);
            await _tagRepository.SaveChangesAsync();

            _logger.LogDebug("Finished save");

            return CreatedAtAction(nameof(Get), new { id = newTag.Id }, newTag);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogDebug("Starting delete");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tag = _tagRepository.GetSingle(id);
            _tagRepository.Delete(tag);
            await _tagRepository.SaveChangesAsync();

            _logger.LogDebug("Finished delete");

            return new NoContentResult();
        }
    }
}