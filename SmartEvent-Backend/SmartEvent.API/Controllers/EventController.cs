using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartEvent.Core.DTO;
using SmartEvent.Core.Models;
using SmartEvent.Services;

namespace SmartEvent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;
        private readonly OrganisationService _organisationService;

        public EventController(EventService eventService, OrganisationService organisationService)
        {
            _eventService = eventService;
            _organisationService = organisationService;
        }

        [Authorize(Roles = "organisation")]
        [HttpPost]
        public async Task<ActionResult<Event>> CreateEventAsync([FromBody] AddEventModel newEvent)
        {

            var claims = HttpContext.User.Claims;
            var UserId = claims.FirstOrDefault(c => c.Type == "uid")?.Value;
            
            var createdEvent = await _eventService.CreateEventAsync(newEvent, UserId);
            return Ok(createdEvent);
        }

        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetAllEventAsync()
        {
            
            var events = await _eventService.GetAllEventAsync();
            return Ok(events);
        }

        [Authorize]
        [HttpGet("my-events")]
        public async Task<ActionResult<List<Event>>> GetAllEventByParticipantAsync()
        {
            var claims = HttpContext.User.Claims;
            var UserId = claims.FirstOrDefault(c => c.Type == "uid")?.Value;
            var events = await _eventService.GetAllEventByParticipantAsync(Guid.Parse(UserId));
            return Ok(events);
        }

        [Authorize(Roles = "organisation")]
        [HttpGet("organisationEvents")]
        public async Task<ActionResult<List<Event>>> GetAllEventByOrganisationIdAsync()
        {
            var claims = HttpContext.User.Claims;
            var organisationId = claims.FirstOrDefault(c => c.Type == "uid")?.Value;
            var events = await _eventService.GetAllEventByOrganisationIdAsync(organisationId);
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventByIdAsync(Guid id)
        {
            
            var eventObj = await _eventService.GetEventByIdAsync(id);
            if (eventObj == null)
            {
                return NotFound();
            }            
            var organisation = await _organisationService.GetOrganisationByIdAsync(Guid.Parse(eventObj.OrganisationId!));
            
            var eventRes = new EventResponseModel
            {
                Id = eventObj.Id,
                Title = eventObj.Title,
                Description = eventObj.Description,
                Location = eventObj.Location,
                ImageUrl = eventObj.ImageUrl,
                StartDate = eventObj.StartDate,
                Capacity = eventObj.Capacity,
                AvailablePlace = eventObj.AvailablePlace,
                createdAt = eventObj.createdAt,
                OrganisationName = organisation.Nom
            };

            return Ok(eventRes);
        }

        [Authorize(Roles = "organisation")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(Guid id,[FromBody] AddEventModel updatedEvent)
        {
            var eventObj = await _eventService.UpdateEventAsync(id, updatedEvent);
            if (eventObj == null)
            {
                return NotFound();
            }

            return Ok(eventObj);
        }

        [Authorize(Roles = "organisation")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            var success = await _eventService.DeleteEvent(id);
            if (!success)
            {
                return NotFound();
            }

            return Ok("Deleted !!!");
        }
    }
}