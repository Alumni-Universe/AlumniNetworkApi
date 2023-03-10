using AlumniNetworkApi.Models;
using AlumniNetworkApi.Models.Dtos.AlumniGroups;
using AutoMapper;

namespace AlumniNetworkApi.Profiles
{
    public class AlumniGroupProfile : Profile
    {
        public AlumniGroupProfile() 
        {
            CreateMap<AlumniGroup, AlumniGroupDto>()
                .ForMember(dto => dto.Posts, opt => opt
                .MapFrom(p => p.Posts.Select(p => p.PostId).ToList()))
                .ForMember(dto => dto.Events, opt => opt
                .MapFrom(e => e.Events.Select(e => e.EventId).ToList()))
                .ForMember(dto => dto.Users, opt => opt
                .MapFrom(u => u.Users.Select(u => u.UserId).ToList()));
            CreateMap<AlumniGroupPostDto, AlumniGroup>();
            CreateMap<AlumniGroupPutDto, AlumniGroup>();
            CreateMap<AlumniGroupInfoDto, AlumniGroup>();
        }
    }
}
