using MediatR;
using MovieApi.Application.Features.Results.MovieResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Queries.MovieQueries
{
    public class GetLatestTop5MovieQuery : IRequest<IList<GetLatestTop5MovieQueryResult>>
    {
    }
}
