using SmartEvent.Core.Models;

namespace SmartEvent.Core.Interfaces
{
    public interface IEventRepository
    {
        public Task<Event> CreateEventAsync(Event newEvent);
        public Task<Event?> GetEventByIdAsync(Guid id);
        public Task<Event?> UpdateEventAsync(Guid id, Event updatedEvent);
        public Task<List<Event>> GetAllEventAsync();
        public Task<bool> DeleteEvent(Guid id);
    }
}