using AutoMapper;
using Library.Core.ViewDto;
using Library.Data.Models;

namespace Library.BL.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Book, BookViewDto>()
           .ReverseMap();
        CreateMap<User, UserViewDto>()
            .ReverseMap();
    }
}
