using SmartEvent.Core.Models;

namespace SmartEvent.Core.Interfaces
{
    public interface IParticipantRepository
    {
        public Task<Participant> CreateParticipantAsync(Participant newParticipant);
        public Task<Participant?> GetParticipantByIdAsync(Guid id);
        public Task<Participant?> UpdateParticipantAsync(Guid id, Participant updatedParticipant);
        public Task<List<Participant>> GetAllParticipantAsync();
        public Task<List<Participant>> GetAllParticipantByEventIdAsync(Guid id);
        public Task<List<Participant>> GetAllParticipantByUserIdAsync(Guid id);
        public Task<bool> DeleteParticipant(Guid id);
    }
}