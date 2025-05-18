using SmartEvent.Core.DTO;
using SmartEvent.Core.Models;

namespace SmartEvent.Core.Interfaces
{
    public interface IEventRepository
    {
        public Task<Event> CreateEventAsync(Event newEvent);
        public Task<Event?> GetEventByIdAsync(Guid id);
        public Task<Event?> UpdateEventAsync(Guid id, AddEventModel updatedEvent);
        public Task UpdateEventAfterRegistrationAsync(Guid id);
        public Task<List<Event>> GetAllEventAsync();
        public Task<List<Event>> GetAllEventByOrganisationIdAsync(string organisationId);
        public Task<bool> DeleteEvent(Guid id);
    }
}