using SmartEvent.Core.DTO;
using SmartEvent.Core.Interfaces;
using SmartEvent.Core.Models;

namespace SmartEvent.Services
{
    public class EventService
    {
        private readonly IEventRepository _eventReposiroty;
        private readonly ParticipantService _participantService;

        public EventService(IEventRepository eventRepository, ParticipantService participantService)
        {
            _eventReposiroty = eventRepository;
            _participantService = participantService;
        }

        public Task<Event> CreateEventAsync(AddEventModel addEventModel, String OrganisationId)
        {
            
            var newEvent = new Event
            {
                Id = Guid.NewGuid(),
                Title = addEventModel.Title,
                Description = addEventModel.Description,
                Location = addEventModel.Location,
                OrganisationId = OrganisationId,
                StartDate = addEventModel.StartDate,
                Capacity = addEventModel.Capacity,
                ImageUrl = addEventModel.ImageUrl,
                AvailablePlace = addEventModel.Capacity
            };
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

        public async Task<List<Event>> GetAllEventByParticipantAsync(Guid userId)
        {
            List<Participant> participants = await _participantService.GetAllParticipantByUserIdAsync(userId);
            List<Event> events = [];
            foreach (var participant in participants)
            {
                var even = await GetEventByIdAsync(participant.EventId);
                if (even != null) events.Add(even);
            }
            return events;
        }

        public async Task<List<Event>> GetAllEventByOrganisationIdAsync(string id)
        {

            return await _eventReposiroty.GetAllEventByOrganisationIdAsync(id);
        }

        public async Task UpdateEventAfterRegistrationAsync(Guid id)
        {
            await _eventReposiroty.UpdateEventAfterRegistrationAsync(id);
        }

        public Task<Event?> GetEventByIdAsync(Guid id)
        {
            return _eventReposiroty.GetEventByIdAsync(id);
        }

        public Task<Event?> UpdateEventAsync(Guid id, AddEventModel updatedEvent)
        {
            return _eventReposiroty.UpdateEventAsync(id, updatedEvent);
        }
    }
}