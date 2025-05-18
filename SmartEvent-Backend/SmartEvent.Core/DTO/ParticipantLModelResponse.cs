using System.ComponentModel.DataAnnotations;

namespace SmartEvent.Core.DTO
{
    public class ParticipantModelResponse
    {
        public string EventId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateRegistration { get; set; }
    }
}