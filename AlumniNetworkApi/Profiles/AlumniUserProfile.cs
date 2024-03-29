﻿using AlumniNetworkApi.Models.Dtos.AlumniGroups;
using AlumniNetworkApi.Models;
using AutoMapper;
using AlumniNetworkApi.Models.Dtos.AlumniUsers;
using AlumniNetworkApi.Models.Dtos.Posts;
using AlumniNetworkApi.Models.Dtos.Events;
using AlumniNetworkApi.Models.Dtos.Rsvps;
using AlumniNetworkApi.Models.Dtos.Topics;

namespace AlumniNetworkApi.Profiles
{
    public class AlumniUserProfile : Profile
    {
        public AlumniUserProfile() 
        {
            CreateMap<AlumniGroup, AlumniGroupInfoDto>()
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<Event, EventInfoDto>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Rsvp, RsvpInfoDto>()
                .ForMember(dest => dest.LastUpdated, opt => opt.MapFrom(src => src.LastUpdated))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId));

            CreateMap<Topic, TopicInfoDto>()
                .ForMember(dest => dest.TopicId, opt => opt.MapFrom(src => src.TopicId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<Post, PostInfoDto>()
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId))
                .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.PostTitle))
                .ForMember(dest => dest.PostMessage, opt => opt.MapFrom(src => src.PostMessage));

            CreateMap<AlumniUser, AlumniUserDto>()
                .ForMember(dto => dto.AlumniGroups, opt => opt
                .MapFrom(src => src.AlumniGroups))
                .ForMember(dto => dto.Events, opt => opt
                .MapFrom(src => src.Events))
                .ForMember(dto => dto.PostSenders, opt => opt
                .MapFrom(src => src.PostSenders))
                .ForMember(dto => dto.PostTargetUserNavigations, opt => opt
                .MapFrom(p => p.PostTargetUserNavigations.Select(p => p.TargetUser).ToList()))
                .ForMember(dto => dto.Rsvps, opt => opt
                .MapFrom(src => src.Rsvps))
                .ForMember(dto => dto.EventsNavigation, opt => opt
                .MapFrom(n => n.EventsNavigation.Select(n => n.CreatedBy).ToList()))
                .ForMember(dto => dto.Groups, opt => opt
                .MapFrom(g => g.Groups.Select(g => g.CreatedBy).ToList()))
                .ForMember(dto => dto.Topics, opt => opt
                .MapFrom(src => src.Topics));
            CreateMap<AlumniUserPostDto, AlumniUser>();
            CreateMap<AlumniUserPutDto, AlumniUser>();
            CreateMap<AlumniUserInfoDto, AlumniUser>();
        }
    }
}
