using AlumniNetworkApi.Models;
using AlumniNetworkApi.Models.Dtos.Events;
using AlumniNetworkApi.Models.Dtos.Posts;
using AutoMapper;

namespace AlumniNetworkApi.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDto>()
                .ForMember(dto => dto.InverseReplyParent, opt => opt
                .MapFrom(p => p.InverseReplyParent.Select(p => p.ReplyParentId).ToList()));
            CreateMap<PostPostDto, Post>();
            CreateMap<PostPutDto, Post>();
            CreateMap<PostInfoDto, Post>();
        }
    }
}
