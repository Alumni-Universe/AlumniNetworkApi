namespace AlumniNetworkApi.Models.Dtos.Events
{
    public class EventPostDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public bool AllowGuests { get; set; }

        public string? BannerImg { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int CreatedBy { get; set; }
    }
}
