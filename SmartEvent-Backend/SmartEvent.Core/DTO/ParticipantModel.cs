using System.ComponentModel.DataAnnotations;

namespace SmartEvent.Core.DTO
{
    public class ParticipantModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string EventId { get; set; }
    }
}