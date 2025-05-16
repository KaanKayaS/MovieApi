using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.DTOs;
using MovieApi.Application.Features.Commands.MovieCommands;
using MovieApi.Application.Interfaces.UnitOfWorks;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        public CreateMovieCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var genres = await unitOfWork.GetReadRepository<Genre>()
                .Find(a => request.GenreIds.Contains(a.Id))
                .ToListAsync();

            var actors = await unitOfWork.GetReadRepository<Actor>()
               .Find(a => request.ActorIds.Contains(a.Id))
               .ToListAsync();

            await unitOfWork.GetWriteRepository<Movie>().AddAsync(new Movie
            {
                Name = request.Name,
                CountryId = request.CountryId,
                MoviePlot = request.MoviePlot,
                PublicationDate = request.PublicationDate,
                ImdbPoint = request.ImdbPoint,
                Image = request.Image,
                Duration = TimeSpan.Parse(request.Duration),
                DirectorId = request.DirectorId,
                Actors = actors,
                Genres = genres,
            });

            await unitOfWork.SaveAsync();

            return Unit.Value;

           
        }
    }
}
