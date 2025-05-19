using MovieApi.Application.Bases;
using MovieApi.Application.Features.Exceptions;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Rules
{
    public class MovieRules : BaseRules
    {
        public Task MovieNameMustNotBeSame(IList<Movie> movies, string requestName)
        {
            if (movies.Any(x => x.Name.Equals(requestName, StringComparison.OrdinalIgnoreCase)))
                throw new MovieNameMustNotBeSameException();

            return Task.CompletedTask;
        }

        public Task MovieNotFound(Movie movie)
        {
            if (movie == null) throw new MovieNotFoundException();
            return Task.CompletedTask;
        }
    }
}
