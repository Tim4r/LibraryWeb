﻿using AutoMapper;

namespace Library.WebAPI.Mapper;

public class ViewDtoToDtoMapper
{
    private static readonly Lazy<IMapper> Lazy = new(() =>
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<ViewDtoToDtoMapperProfile>();
        });
        var mapper = config.CreateMapper();
        return mapper;
    });

    public static IMapper Mapper = Lazy.Value;
}

