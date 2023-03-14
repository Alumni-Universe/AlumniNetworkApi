using AlumniNetworkApi.Models;
using AlumniNetworkApi.Models.Dtos.Topics;
using AutoMapper;

namespace AlumniNetworkApi.Profiles
{
    public class TopicProfile : Profile
    {
        public TopicProfile()
        {
            CreateMap<Topic, TopicDto>()
                .ForMember(dto => dto.Posts, opt => opt
                .MapFrom(p => p.Posts.Select(p => p.PostId).ToList()))
                .ForMember(dto => dto.Events, opt => opt
                .MapFrom(e => e.Events.Select(e => e.EventId).ToList()))
                .ForMember(dto => dto.Users, opt => opt
                .MapFrom(u => u.Users.Select(u => u.UserId).ToList()));
            CreateMap<TopicPostDto, Topic>();
            CreateMap<TopicPutDto, Topic>();
            CreateMap<TopicInfoDto, Topic>();
        }
    }
}
