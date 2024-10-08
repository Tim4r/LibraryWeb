using AutoMapper;
using Library.Core.ViewDto;
using Library.Data.Models;

namespace Library.WebAPI.Mapper;

public class ApiMapperProfile
{
    public class ApiToModelMapperProfile : Profile
    {
        public ApiToModelMapperProfile()
        {
            CreateMap<Book, BookViewDto>()
               .ReverseMap();
            CreateMap<User, UserViewDto>()
                .ReverseMap();
        }

    }
}
