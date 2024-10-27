using AutoMapper;
using Library.Core.Dtos;
using Library.Core.ViewDto;
using Library.Core.ViewDtos;

namespace Library.WebAPI.Mapper;

public class ViewDtoToDtoMapperProfile : Profile
{
    public ViewDtoToDtoMapperProfile()
    {
        CreateMap<BookViewDto, BookDto>().ReverseMap();
        CreateMap<UserViewDto, RegisterDto>().ReverseMap();
        CreateMap<BookLoanViewDto, BookLoanDto>().ReverseMap();
        CreateMap<AuthorViewDto, AuthorDto>().ReverseMap();
    }
}
