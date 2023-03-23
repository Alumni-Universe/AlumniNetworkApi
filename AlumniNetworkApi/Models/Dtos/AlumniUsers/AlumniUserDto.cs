using AlumniNetworkApi.Models.Dtos.AlumniGroups;
using AlumniNetworkApi.Models.Dtos.Events;
using AlumniNetworkApi.Models.Dtos.Rsvps;
using AlumniNetworkApi.Models.Dtos.Topics;

namespace AlumniNetworkApi.Models.Dtos.AlumniUsers
{
    public class AlumniUserDto
    {
        public string UserId { get; set; }

        public string Name { get; set; } = null!;

        public string Picture { get; set; } = null!;

        public string? Status { get; set; }

        public string? Bio { get; set; }

        public string? FunFact { get; set; }
        public List<AlumniGroupInfoDto>? AlumniGroups { get; set; }
        public List<EventInfoDto>? Events { get; set; }
        public List<int>? PostSenders { get; set; }
        public List<int>? PostTargetUserNavigations { get; set; }
        public List<RsvpInfoDto>? Rsvps { get; set; }
        public List<int>? EventsNavigation { get; set; }
        public List<int>? Groups { get; set; }
        public List<TopicInfoDto>? Topics { get; set; }
    }
}
