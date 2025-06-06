namespace SmartEvent.Core.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? OrganisationId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public int Capacity { get; set; }
        public int AvailablePlace { get; set; }
        public DateTime createdAt { get; set; } = DateTime.UtcNow;

    }
}