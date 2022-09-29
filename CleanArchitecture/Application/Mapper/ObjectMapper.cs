using Application.Models;
using AutoMapper;
using Domain.Entities;
using System;

namespace Application.Mapper
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
              {
                  var config = new MapperConfiguration(cfg =>
                  {
                      cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                      cfg.AddProfile<MapperProfile>();
                  });
                  var mapper = config.CreateMapper();
                  return mapper;
              });

        public static IMapper Mapper => Lazy.Value;
    }

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Movie, MovieModel>().ReverseMap();
        }
    }
}