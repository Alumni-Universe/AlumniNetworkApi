using AlumniNetworkApi.Models;
using AlumniNetworkApi.Models.Dtos.AlumniGroups;
using AlumniNetworkApi.Models.Dtos.AlumniUsers;
using AlumniNetworkApi.Models.Dtos.Events;
using AlumniNetworkApi.Models.Dtos.Posts;
using AlumniNetworkApi.Models.Dtos.Rsvps;
using AlumniNetworkApi.Models.Dtos.Topics;
using AutoMapper;

namespace AlumniNetworkApi.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Post, PostInfoDto>()
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId))
                .ForMember(dest => dest.PostTarget, opt => opt.MapFrom(src => src.PostTarget));

            CreateMap<Rsvp, RsvpInfoDto>()
                .ForMember(dest => dest.LastUpdated, opt => opt.MapFrom(src => src.LastUpdated))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId));

            CreateMap<AlumniGroup, AlumniGroupInfoDto>()
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Topic, TopicInfoDto>()
                .ForMember(dest => dest.TopicId, opt => opt.MapFrom(src => src.TopicId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<AlumniUser, AlumniUserInfoDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Event, EventDto>()
                .ForMember(dto => dto.Posts, opt => opt
                .MapFrom(src => src.Posts))
                .ForMember(dto => dto.Rsvps, opt => opt
                .MapFrom(src => src.Rsvps))
                .ForMember(dto => dto.Groups, opt => opt
                .MapFrom(src => src.Groups))
                .ForMember(dto => dto.Topics, opt => opt
                .MapFrom(src => src.Topics))
                .ForMember(dto => dto.Users, opt => opt
                .MapFrom(src => src.Users));
            CreateMap<EventPostDto, Event>();
            CreateMap<EventPutDto, Event>();
            CreateMap<EventInfoDto, Event>();
        }
    }
}
