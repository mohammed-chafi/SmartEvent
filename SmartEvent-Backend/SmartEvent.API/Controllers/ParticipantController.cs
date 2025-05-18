using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartEvent.Core.DTO;
using SmartEvent.Core.Models;
using SmartEvent.Services;

namespace SmartEvent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ParticipantController : ControllerBase
    {
        private readonly ParticipantService _participantService;

        public ParticipantController(ParticipantService participantService)
        {
            _participantService = participantService;
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public async Task<ActionResult> JoinEvent(ParticipantModel participantModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var claims = HttpContext.User.Claims;
            var UserId = claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            var result = await _participantService.CreateParticipantAsync(participantModel, UserId);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Participant>> GetParticipantById(Guid id)
        {

            var eventObj = await _participantService.GetParticipantByIdAsync(id);
            if (eventObj == null)
            {
                return NotFound();
            }
            return Ok(eventObj);
        }

        [Authorize]
        [HttpGet("allByUserId")]
        public async Task<ActionResult<List<Participant>>> GetAllParticipantByUserId()
        {
            var claims = HttpContext.User.Claims;
            var UserId = claims.FirstOrDefault(c => c.Type == "uid")?.Value;
            var eventObj = await _participantService.GetAllParticipantByUserIdAsync(Guid.Parse(UserId));
            if (eventObj == null)
            {
                return NotFound();
            }
            return Ok(eventObj);
        }

        [Authorize]
        [HttpGet("allByEventId/{id}")]
        public async Task<ActionResult<List<Participant>>> GetAllParticipantByEventId(Guid id)
        {
            var eventObj = await _participantService.GetAllParticipantByEventIdAsync(id);
            if (eventObj == null)
            {
                return NotFound();
            }
            return Ok(eventObj);
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> LeavEvent(Guid participantId)
        {

            var success = await _participantService.DeleteParticipant(participantId);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}