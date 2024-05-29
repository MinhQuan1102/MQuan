using api.DTOModels;
using api.DTOModels.MQSocial;
using api.Entities;
using api.Entities.MQSocial;
using AutoMapper;

namespace api.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<RegisterDTO, User>();
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
                .ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src.Posts));
            CreateMap<UserDTO, User>();
            CreateMap<Image, ImageDTO>();

            // Post
            CreateMap<Post, PostDTO>()
                .ForMember(dest => dest.Reactions, opt => opt.MapFrom(src => src.Reactions.Select(r => new PostReactionDTO
                {
                    Type = r.Type,
                    UserId = r.UserId
                })));
            CreateMap<Post, CreatePostDTO>();
            CreateMap<PostReaction, PostReactionDTO>();
            CreateMap<PostReactionDTO, PostReaction>();

            CreateMap<DateTime, DateTime>().ConvertUsing(d => DateTime.SpecifyKind(d, DateTimeKind.Utc));
            CreateMap<DateTime?, DateTime?>().ConvertUsing(d => d.HasValue ? DateTime.SpecifyKind(d.Value, DateTimeKind.Utc) : null);
        }
    }
}
