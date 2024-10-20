using AutoMapper;
using Library.Core.Dtos;
using Library.Data.Models;

namespace Library.BL.Mapper;

public class ModelToDtoMapperProfile : Profile
{
    public ModelToDtoMapperProfile()
    {
        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<BookLoan, BookLoanDto>().ReverseMap();
    }
}
