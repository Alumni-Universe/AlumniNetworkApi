using AlumniNetworkApi.Models.Dtos.AlumniUsers;
using AlumniNetworkApi.Models.Dtos.Events;
using AlumniNetworkApi.Models.Dtos.Posts;

namespace AlumniNetworkApi.Models.Dtos.Topics
{
    public class TopicDto
    {
        public int TopicId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public List<PostInfoDto>? Posts { get; set; }
        public List<EventInfoDto>? Events { get; set; }
        public List<AlumniUserInfoDto>? Users { get; set; }
    }
}
