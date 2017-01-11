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
    public class SkillsMetadataController : Controller
    {
        private readonly ISkillsMetadataRepository _skillsMetadataRepository;
        private readonly ILogger<SkillsController> _logger; 

        public SkillsMetadataController(ISkillsMetadataRepository skillsMetadataRepository, ILogger<SkillsController> logger)
        {
            _skillsMetadataRepository = skillsMetadataRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Get()
        {
            var skillsMetadata = await _skillsMetadataRepository.Get();
            if (skillsMetadata == null)
            {
                return NotFound();  
            }

            return new ObjectResult(skillsMetadata);
        }

    }
}