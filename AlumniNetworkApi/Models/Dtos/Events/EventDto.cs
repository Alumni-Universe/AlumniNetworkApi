namespace AlumniNetworkApi.Models.Dtos.Events
{
    public class EventDto
    {
        public int EventId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public bool AllowGuests { get; set; }

        public string? BannerImg { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int CreatedBy { get; set; }
        public List<int>? Posts { get; set; }
        public List<int>? Rsvps { get; set; }
        public List<int>? Groups { get; set; }
        public List<int>? Topics { get; set; }
        public List<int>? Users { get; set; }
    }
}
