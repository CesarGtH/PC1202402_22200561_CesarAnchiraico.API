using EventManagementDB.DOMAIN.Core.Entities;
using EventManagementDB.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PC1202402_22200561_CesarAnchiraico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizersController : ControllerBase
    {
        private readonly IOrganizersRepository _organizersRepository;

        public OrganizersController(IOrganizersRepository organizersRepository)
        {
            _organizersRepository = organizersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganizers()
        {
            var organizers = await _organizersRepository.GetOrganizers();
            return Ok(organizers);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetOrganizersbyid(int id)
        {
            var organizers = await _organizersRepository.GetOrganizersbyid(id);
            if (organizers == null) return NotFound();
            return Ok(organizers);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody]Organizers organizers)
        {
            int id = await _organizersRepository.Insert(organizers);
            return Ok(id);
        }

    }
}
