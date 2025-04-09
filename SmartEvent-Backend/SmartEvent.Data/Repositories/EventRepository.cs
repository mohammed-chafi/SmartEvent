using Microsoft.EntityFrameworkCore;
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
            newEvent.Id = Guid.NewGuid();
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

        public async Task<Event?> GetEventByIdAsync(Guid id)
        {
            return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Event?> UpdateEventAsync(Guid id, Event updatedEvent)
        {
            var existingEvent = await GetEventByIdAsync(id);
            if (existingEvent == null) return null;

            existingEvent.Name = updatedEvent.Name;
            existingEvent.Description = updatedEvent.Description;
            existingEvent.StartDate = updatedEvent.StartDate;
            existingEvent.EndDate = updatedEvent.EndDate;
            existingEvent.Location = updatedEvent.Location;
            existingEvent.Price = updatedEvent.Price;
            existingEvent.Capacity = updatedEvent.Capacity;

            await _context.SaveChangesAsync();

            return existingEvent;
        }
    }
}