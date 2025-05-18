using SmartEvent.Core.Models;

namespace SmartEvent.Core.Interfaces
{
    public interface IParticipantRepository
    {
        public Task<Participant> CreateParticipantAsync(Participant participant);
        public Task<Participant?> GetParticipantByIdAsync(Guid id);
        public Task<Participant?> GetParticipantByUserIdAsync(Guid id);
        public Task<List<Participant>> GetAllParticipantAsync();
        public Task<List<Participant>> GetAllParticipantByEventIdAsync(Guid id);
        public Task<List<Participant>> GetAllParticipantByUserIdAsync(Guid id);
        public Task<bool> DeleteParticipant(Guid id);
    }
}