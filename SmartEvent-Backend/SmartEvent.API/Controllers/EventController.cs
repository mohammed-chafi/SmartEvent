using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartEvent.Core.Models;
using SmartEvent.Services;

namespace SmartEvent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Event>> CreateEventAsync([FromBody] Event newEvent)
        {
            var createdEvent = await _eventService.CreateEventAsync(newEvent);
            return Ok(createdEvent);
        }

        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetAllEventAsync()
        {
            var events = await _eventService.GetAllEventAsync();
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
            return Ok(eventObj);
        }

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Event> UpdateEvent(Guid id, Event updatedEvent)
        {
            var eventObj = _eventService.UpdateEventAsync(id, updatedEvent);
            if (eventObj == null)
            {
                return NotFound();
            }

            return Ok(eventObj);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            var success = await _eventService.DeleteEvent(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}