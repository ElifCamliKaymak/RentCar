using AutoMapper;
using RentCar.Bussiness.Dtos.CommentDtos;
using RentCar.Domain.Entities;
using RentCar.Dtos.Dtos.CommentDtos;

namespace RentCar.WebApi.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateCommentDto, Comment>();
            CreateMap<Comment, GetCommentDto>()
                .ForMember(dest => dest.BlogTitle, opt => opt.MapFrom(src => src.Blog.Title));
        }

    }
}
