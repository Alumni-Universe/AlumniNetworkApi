using AlumniNetworkApi.Models.Dtos.AlumniGroups;
using AlumniNetworkApi.Models;
using AutoMapper;
using AlumniNetworkApi.Models.Dtos.AlumniUsers;

namespace AlumniNetworkApi.Profiles
{
    public class AlumniUserProfile : Profile
    {
        public AlumniUserProfile() 
        {
            CreateMap<AlumniUser, AlumniUserDto>()
                .ForMember(dto => dto.AlumniGroups, opt => opt
                .MapFrom(g => g.AlumniGroups.Select(g => g.GroupId).ToList()))
                .ForMember(dto => dto.Events, opt => opt
                .MapFrom(e => e.Events.Select(e => e.EventId).ToList()))
                .ForMember(dto => dto.PostSenders, opt => opt
                .MapFrom(p => p.PostSenders.Select(p => p.SenderId).ToList()))
                .ForMember(dto => dto.PostTargetUserNavigations, opt => opt
                .MapFrom(p => p.PostTargetUserNavigations.Select(p => p.TargetUser).ToList()))
                .ForMember(dto => dto.Rsvps, opt => opt
                .MapFrom(r => r.Rsvps.Select(r =>  r.UserId).ToList()))
                .ForMember(dto => dto.EventsNavigation, opt => opt
                .MapFrom(n => n.EventsNavigation.Select(n => n.CreatedBy).ToList()))
                .ForMember(dto => dto.Groups, opt => opt
                .MapFrom(g => g.Groups.Select(g => g.CreatedBy).ToList()))
                .ForMember(dto => dto.Topics, opt => opt
                .MapFrom(t => t.Topics.Select(t => t.TopicId).ToList()));
            CreateMap<AlumniUserPostDto, AlumniUser>();
            CreateMap<AlumniUserPutDto, AlumniUser>();
            CreateMap<AlumniUserInfoDto, AlumniUser>();
        }
    }
}
