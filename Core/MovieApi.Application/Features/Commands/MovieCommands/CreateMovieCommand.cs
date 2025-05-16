using MediatR;
using MovieApi.Application.DTOs;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Commands.MovieCommands
{
    public class CreateMovieCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string MoviePlot { get; set; }
        public DateTime PublicationDate { get; set; }
        public double ImdbPoint { get; set; }
        public int CountryId { get; set; }
        public string Image { get; set; }
        public string Duration { get; set; }
        public int DirectorId { get; set; }
        public IList<int> GenreIds { get; set; }
        public IList<int> ActorIds { get; set; }
    }
}
