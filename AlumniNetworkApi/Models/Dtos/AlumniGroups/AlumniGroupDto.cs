using AlumniNetworkApi.Models.Dtos.Posts;
using AlumniNetworkApi.Models.Dtos.Events;
using AlumniNetworkApi.Models.Dtos.AlumniUsers;
namespace AlumniNetworkApi.Models.Dtos.AlumniGroups
{
    public class AlumniGroupDto
    {
        public int GroupId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool IsPrivate { get; set; }

        public int CreatedBy { get; set; }
        public List<PostInfoDto>? Posts { get; set; }
        public List<EventInfoDto>? Events { get; set; }
        public List<AlumniUserInfoDto>? Users { get; set; }
    }
}
