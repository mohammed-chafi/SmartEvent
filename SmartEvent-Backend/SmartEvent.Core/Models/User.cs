namespace SmartEvent.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Guid AuthId { get; set; }
    }
}