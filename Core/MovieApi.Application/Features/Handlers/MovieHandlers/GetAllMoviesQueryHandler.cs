using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.DTOs;
using MovieApi.Application.Features.Queries.MovieQueries;
using MovieApi.Application.Features.Results.MovieResults;
using MovieApi.Application.Interfaces.UnitOfWorks;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Handlers.MovieHandlers
{
    public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, IList<GetAllMoviesQueryResult>>
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllMoviesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllMoviesQueryResult>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var values = await unitOfWork.GetReadRepository<Movie>().GetAllAsync(include: x=> x
                                                                                .Include(x=> x.Country)
                                                                                .Include(x => x.Director)
                                                                                .Include(x => x.Genres)
                                                                                .Include(x => x.Actors));


             return mapper.Map<IList<GetAllMoviesQueryResult>>(values);


        }
    }
}
