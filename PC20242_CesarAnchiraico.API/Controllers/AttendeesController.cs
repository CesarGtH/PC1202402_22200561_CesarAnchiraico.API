using EventManagementDB.DOMAIN.Core.Entities;
using EventManagementDB.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PC1202402_22200561_CesarAnchiraico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {
        private readonly IAttendeesRepository _attendeesRepository;

        public AttendeesController(IAttendeesRepository attendeesRepository)
        {
            _attendeesRepository = attendeesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAttendees()
        {
            var attendees = await _attendeesRepository.GetAttendees();
            return Ok(attendees);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetAttendeesbyid(int id)
        {
            var attendees = await _attendeesRepository.GetAttendeessbyid(id);
            if (attendees == null) return NotFound();
            return Ok(attendees);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] Attendees attendees)
        {
            int id = await _attendeesRepository.Insert(attendees);
            return Ok(id);
        }

    }
}
