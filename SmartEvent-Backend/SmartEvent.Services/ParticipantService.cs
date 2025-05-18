using SmartEvent.Core.DTO;
using SmartEvent.Core.Interfaces;
using SmartEvent.Core.Models;
using SmartEvent.Data.Repositories;

namespace SmartEvent.Services
{
    public class ParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IEventRepository _eventReposiroty;
        private readonly IUserRepository _userRepository;


        public ParticipantService(IParticipantRepository participantRepository, IEventRepository eventReposiroty,IUserRepository userRepository)
        {
            _participantRepository = participantRepository;
            _eventReposiroty = eventReposiroty;
            _userRepository = userRepository;

        }

        public async Task<string> CreateParticipantAsync(ParticipantModel participantModel, string userId)
        {
            try
            {
                var participantChack = await _participantRepository.GetParticipantByUserIdAsync(Guid.Parse(userId));
                var eventCheck = await _eventReposiroty.GetEventByIdAsync(Guid.Parse(participantModel.EventId));
                if (eventCheck.AvailablePlace == 0) return "No places left";
                if (participantChack != null) return "Already registered";

                var participant = new Participant
                {
                    Id = new Guid(),
                    createdAt = new DateTime(),
                    EventId = Guid.Parse(participantModel.EventId),
                    UserId = Guid.Parse(userId)
                };
                await _participantRepository.CreateParticipantAsync(participant);
                await _eventReposiroty.UpdateEventAfterRegistrationAsync(participant.EventId);
                return "Registered successfully";
            }
            catch (System.Exception)
            {

                Console.WriteLine("erereur !!!!");
                return "erreur";
            }

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

        public async Task<List<ParticipantModelResponse>> GetAllParticipantByEventIdAsync(Guid id)
        {
            
            List<Participant> participants = await _participantRepository.GetAllParticipantByEventIdAsync(id);
            List<ParticipantModelResponse> participantModelResponse = [];
            
            if(participants == null ) return [];
            
            foreach (Participant item in participants)
            {
                Console.WriteLine(item.UserId);
                var user = await _userRepository.GetUserByIdAsync(item.UserId);
                if(user == null) return [];
                var participantReponse = new ParticipantModelResponse {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateRegistration = item.createdAt.ToString(),
                    EventId = item.EventId.ToString()
                };
                Console.WriteLine("<<<<<<<<<<<<<<<<<gggggg>>>>>>>>>>>>>>>>>");
                participantModelResponse.Add(participantReponse);

            }
            return participantModelResponse;
        }

        public Task<Participant?> GetParticipantByIdAsync(Guid id)
        {
            return _participantRepository.GetParticipantByIdAsync(id);
        }

    }
}