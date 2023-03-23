using AlumniNetworkApi.Models.Dtos.AlumniGroups;
using AlumniNetworkApi.Models.Dtos.AlumniUsers;
using AlumniNetworkApi.Models.Dtos.Posts;
using AlumniNetworkApi.Models.Dtos.Rsvps;
using AlumniNetworkApi.Models.Dtos.Topics;

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

        public string CreatedBy { get; set; }
        public List<PostInfoDto>? Posts { get; set; }
        public List<RsvpInfoDto>? Rsvps { get; set; }
        public List<AlumniGroupInfoDto>? Groups { get; set; }
        public List<TopicInfoDto>? Topics { get; set; }
        public List<AlumniUserInfoDto>? Users { get; set; }
    }
}
