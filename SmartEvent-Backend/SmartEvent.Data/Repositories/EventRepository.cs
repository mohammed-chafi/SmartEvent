using Microsoft.EntityFrameworkCore;
using SmartEvent.Core.DTO;
using SmartEvent.Core.Interfaces;
using SmartEvent.Core.Models;
using SmartEvent.Data.Db;

namespace SmartEvent.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Event> CreateEventAsync(Event newEvent)
        {
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();
            return newEvent;
        }

        public async Task<bool> DeleteEvent(Guid id)
        {
            var eventToDelete = await GetEventByIdAsync(id);
            if (eventToDelete == null) return false;
            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<Event>> GetAllEventAsync()
        {
            return _context.Events.ToListAsync();
        }

        public async Task<List<Event>> GetAllEventByOrganisationIdAsync(string organisationId)
        {
            return await _context.Events.Where(e => e.OrganisationId!.Equals(organisationId)).ToListAsync();
        }

        public async Task<Event?> GetEventByIdAsync(Guid id)
        {
            var events = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
            return events;
        }

        public async Task UpdateEventAfterRegistrationAsync(Guid id)
        {
            var existingEvent = await GetEventByIdAsync(id);
            if (existingEvent == null) return;
            existingEvent.AvailablePlace = existingEvent.AvailablePlace - 1;

            await _context.SaveChangesAsync();
        }

        public async Task<Event?> UpdateEventAsync(Guid id, AddEventModel updatedEvent)
        {
            
            var existingEvent = await GetEventByIdAsync(id);
            if (existingEvent == null) return null;
            existingEvent.Title = updatedEvent.Title;
            existingEvent.Description = updatedEvent.Description;
            existingEvent.StartDate = updatedEvent.StartDate;
            existingEvent.Location = updatedEvent.Location;
            existingEvent.Capacity = updatedEvent.Capacity;
            existingEvent.AvailablePlace = updatedEvent.Capacity;

            await _context.SaveChangesAsync();

            return existingEvent;
        }
    }
}