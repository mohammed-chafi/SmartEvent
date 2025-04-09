using SmartEvent.Core.Interfaces;
using SmartEvent.Core.Models;

namespace SmartEvent.Services
{
    public class EventService
    {
        private readonly IEventRepository _eventReposiroty;

        public EventService(IEventRepository eventRepository)
        {
            _eventReposiroty = eventRepository;
        }

        public Task<Event> CreateEventAsync(Event newEvent)
        {
            return _eventReposiroty.CreateEventAsync(newEvent);
        }

        public Task<bool> DeleteEvent(Guid id)
        {
            return _eventReposiroty.DeleteEvent(id);
        }

        public Task<List<Event>> GetAllEventAsync()
        {
            return _eventReposiroty.GetAllEventAsync();
        }

        public Task<Event?> GetEventByIdAsync(Guid id)
        {
            return _eventReposiroty.GetEventByIdAsync(id);
        }

        public Task<Event?> UpdateEventAsync(Guid id, Event updatedEvent)
        {
            return _eventReposiroty.UpdateEventAsync(id, updatedEvent);
        }
    }
}