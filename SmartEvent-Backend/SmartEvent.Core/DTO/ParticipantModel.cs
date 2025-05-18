using System.ComponentModel.DataAnnotations;

namespace SmartEvent.Core.DTO
{
    public class ParticipantModel
    {
        [Required]
        public string EventId { get; set; }
    }
}