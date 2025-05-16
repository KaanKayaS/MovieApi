using AutoMapper;
using MovieApi.Application.DTOs;
using MovieApi.Application.Features.Commands.MovieCommands;
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
               .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
               .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
               .ReverseMap();

            CreateMap<Movie, GetAllMoviesQueryResult>()
             .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name))
             .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.Director.FullName))
             .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors))
             .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres))
             .ReverseMap();


            CreateMap<Movie, GetLatestTop5MovieQueryResult>()
               .ReverseMap();


            CreateMap<CreateMovieCommand, Movie>()
           .ForMember(dest => dest.Genres, opt => opt.Ignore())
           .ForMember(dest => dest.Actors, opt => opt.Ignore())
           .ForMember(dest => dest.Director, opt => opt.Ignore());

            CreateMap<ActorDto, Actor>();
            CreateMap<DirectorDto, Director>();


        }
    }
    
}
