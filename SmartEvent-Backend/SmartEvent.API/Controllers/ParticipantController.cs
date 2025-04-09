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

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Participant>> JoinEvent(ParticipantModel participantModel)
        {
            var participant = new Participant
            {
                EventId = Guid.Parse(participantModel.EventId),
                UserId = Guid.Parse(participantModel.UserId)
            };

            var createdParticipant = await _participantService.CreateParticipantAsync(participant);

            return Ok(createdParticipant);
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