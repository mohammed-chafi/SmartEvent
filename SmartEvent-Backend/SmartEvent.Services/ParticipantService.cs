using SmartEvent.Core.Models;
using SmartEvent.Data.Repositories;

namespace SmartEvent.Services
{
    public class ParticipantService
    {
        private readonly ParticipantRepository _participantRepository;

        public ParticipantService(ParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public Task<Participant> CreateParticipantAsync(Participant newParticipant)
        {
            return _participantRepository.CreateParticipantAsync(newParticipant);
        }

        public Task<bool> DeleteParticipant(Guid id)
        {
            return _participantRepository.DeleteParticipant(id);
        }

        public Task<List<Participant>> GetAllParticipantAsync()
        {
            return _participantRepository.GetAllParticipantAsync();
        }

        public Task<List<Participant>> GetAllParticipantByUserIdAsync(Guid id)
        {
            return _participantRepository.GetAllParticipantByUserIdAsync(id);
        }

        public Task<List<Participant>> GetAllParticipantByEventIdAsync(Guid id)
        {
            return _participantRepository.GetAllParticipantByEventIdAsync(id);
        }

        public Task<Participant?> GetParticipantByIdAsync(Guid id)
        {
            return _participantRepository.GetParticipantByIdAsync(id);
        }

        public Task<Participant?> UpdateParticipantAsync(Guid id, Participant updatedParticipant)
        {
            return _participantRepository.UpdateParticipantAsync(id, updatedParticipant);
        }

    }
}