namespace AlumniNetworkApi.Models.Dtos.Events
{
    public class EventPutDto
    {
        public int EventId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public bool AllowGuests { get; set; }

        public string? BannerImg { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string CreatedBy { get; set; }
    }
}
