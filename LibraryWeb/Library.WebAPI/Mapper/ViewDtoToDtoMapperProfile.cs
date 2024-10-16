using AutoMapper;
using Library.Core.Dtos;
using Library.Core.ViewDto;

namespace Library.WebAPI.Mapper;

public class ViewDtoToDtoMapperProfile : Profile
{
    public ViewDtoToDtoMapperProfile()
    {
        CreateMap<BookViewDto, BookDto>().ReverseMap();
        CreateMap<UserViewDto, UserDto>().ReverseMap();
    }
}
