using AlumniNetworkApi.Models;
using AlumniNetworkApi.Models.Dtos.Events;
using AutoMapper;

namespace AlumniNetworkApi.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>()
                .ForMember(dto => dto.Posts, opt => opt
                .MapFrom(p => p.Posts.Select(p => p.PostId).ToList()))
                .ForMember(dto => dto.Rsvps, opt => opt
                .MapFrom(r => r.Rsvps.Select(r => r.UserId).ToList()))
                .ForMember(dto => dto.Groups, opt => opt
                .MapFrom(g => g.Groups.Select(g => g.GroupId).ToList()))
                .ForMember(dto => dto.Topics, opt => opt
                .MapFrom(t => t.Topics.Select(t => t.TopicId).ToList()))
                .ForMember(dto => dto.Users, opt => opt
                .MapFrom(u => u.Users.Select(u => u.UserId).ToList()));
            CreateMap<EventPostDto, Event>();
            CreateMap<EventPutDto, Event>();
            CreateMap<EventInfoDto, Event>();
        }
    }
}
