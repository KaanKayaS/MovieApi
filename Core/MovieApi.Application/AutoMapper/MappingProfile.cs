using AutoMapper;
using MovieApi.Application.DTOs;
using MovieApi.Application.Features.Results.MovieResults;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {

            CreateMap<Genre, GenreDto>()
                .ForMember(dest => dest.Id , opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<Actor, ActorDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
               .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
               .ReverseMap();

            CreateMap<Movie, GetAllMoviesQueryResult>()
             .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name))
             .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.Director.Name))
             .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors))
             .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres))
             .ReverseMap();


        }
    }
}
