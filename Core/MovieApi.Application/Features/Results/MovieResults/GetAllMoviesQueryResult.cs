using MovieApi.Application.DTOs;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Results.MovieResults
{
    public class GetAllMoviesQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MoviePlot { get; set; }
        public DateTime PublicationDate { get; set; }
        public int DirectorId { get; set; }
        public double ImdbPoint { get; set; }
        public int CountryId { get; set; }
        public string Image { get; set; }
        public TimeSpan Duration { get; set; }
        public string CountryName { get; set; }
        public string DirectorName { get; set; }
        public IList<GenreDto> Genres { get; set; }
        public IList<ActorDto> Actors { get; set; }
    }
}
