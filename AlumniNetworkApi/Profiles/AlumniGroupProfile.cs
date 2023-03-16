using AlumniNetworkApi.Models;
using AlumniNetworkApi.Models.Dtos.AlumniGroups;
using AlumniNetworkApi.Models.Dtos.Posts;
using AlumniNetworkApi.Models.Dtos.Events;
using AlumniNetworkApi.Models.Dtos.AlumniUsers;
using AutoMapper;

namespace AlumniNetworkApi.Profiles
{
    public class AlumniGroupProfile : Profile
    {
        public AlumniGroupProfile() 
        {
            CreateMap<Post, PostInfoDto>()
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId))
                .ForMember(dest => dest.PostTarget, opt => opt.MapFrom(src => src.PostTarget));

            CreateMap<Event, EventInfoDto>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<AlumniUser, AlumniUserInfoDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<AlumniGroup, AlumniGroupDto>()
                .ForMember(dto => dto.Posts, opt => opt.MapFrom(src => src.Posts))
                .ForMember(dto => dto.Events, opt => opt.MapFrom(src => src.Events))
                .ForMember(dto => dto.Users, opt => opt.MapFrom(src => src.Users));
            CreateMap<AlumniGroupPostDto, AlumniGroup>();
            CreateMap<AlumniGroupPutDto, AlumniGroup>();
            CreateMap<AlumniGroupInfoDto, AlumniGroup>();
        }
    }
}
