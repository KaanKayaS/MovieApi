using AutoMapper;
using MediatR;
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
    public class GetLatestTop5MovieQueryHandler : IRequestHandler<GetLatestTop5MovieQuery, IList<GetLatestTop5MovieQueryResult>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetLatestTop5MovieQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetLatestTop5MovieQueryResult>> Handle(GetLatestTop5MovieQuery request, CancellationToken cancellationToken)
        {
            IList<Movie> values = await unitOfWork.GetReadRepository<Movie>().GetAllAsync(orderBy: x => x.OrderByDescending(m => m.CreatedDate));

            List<Movie> top5 = values.Take(5).ToList();

            return mapper.Map<IList<GetLatestTop5MovieQueryResult>>(top5);
        }
    }
}
