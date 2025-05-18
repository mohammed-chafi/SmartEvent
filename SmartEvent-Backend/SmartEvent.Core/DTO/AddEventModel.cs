namespace SmartEvent.Core.DTO
{
    public class AddEventModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public int Capacity { get; set; }
    }
}