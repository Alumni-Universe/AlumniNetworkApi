using AlumniNetworkApi.Models;
using AlumniNetworkApi.Models.Dtos.AlumniGroups;
using AlumniNetworkApi.Models.Dtos.AlumniUsers;
using AlumniNetworkApi.Models.Dtos.Events;
using AlumniNetworkApi.Models.Dtos.Posts;
using AlumniNetworkApi.Models.Dtos.Topics;
using AutoMapper;

namespace AlumniNetworkApi.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<AlumniUser, AlumniUserInfoDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            
            CreateMap<Event, EventInfoDto>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<AlumniGroup, AlumniGroupInfoDto>()
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            
            CreateMap<Topic, TopicInfoDto>()
                .ForMember(dest => dest.TopicId, opt => opt.MapFrom(src => src.TopicId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
                
            CreateMap<Post, PostDto>()
                .ForMember(dto => dto.InverseReplyParent, opt => opt
                .MapFrom(p => p.InverseReplyParent.Select(p => p.ReplyParentId).ToList()))
                .ForMember(dto => dto.Sender, opt => opt
                .MapFrom(src => src.Sender))
                .ForMember(dto => dto.TargetEventNavigation, opt => opt
                .MapFrom(src => src.TargetEventNavigation))
                .ForMember(dto => dto.TargetGroupNavigation, opt => opt
                .MapFrom(src => src.TargetGroupNavigation))
                .ForMember(dto => dto.TargetTopicNavigation, opt => opt
                .MapFrom(src => src.TargetTopicNavigation))
                .ForMember(dto => dto.TargetUserNavigation, opt => opt
                .MapFrom(src => src.TargetUserNavigation));
            CreateMap<PostPostDto, Post>();
            CreateMap<PostPutDto, Post>();
            CreateMap<PostInfoDto, Post>();
        }
    }
}
