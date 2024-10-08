using AutoMapper;
using Library.Core.Dtos;
using Library.Core.ViewDto;

namespace Library.WebAPI.Mapper;

public class DtoToViewDtoMapperProfile : Profile
{
    public DtoToViewDtoMapperProfile()
    {
        CreateMap<BookDto, BookViewDto>()
            .ReverseMap();
        CreateMap<UserDto, UserViewDto>()
            .ReverseMap();
    }
}
