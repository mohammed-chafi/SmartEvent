using SmartEvent.Core.Models;

namespace SmartEvent.Core.DTO
{
    public class EventResponseModel
    {

        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public int Capacity { get; set; }
        public int AvailablePlace { get; set; }
        public DateTime createdAt { get; set; }

        public string? OrganisationName { get; set; }
    }
}