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
    public class SeriesRules : BaseRules
    {
        public Task SeriesNameMustNotBeSame(IList<Series> series, string requestName)
        {
            if (series.Any(x => x.Name.Equals(requestName, StringComparison.OrdinalIgnoreCase)))
                throw new SeriesNameMustNotBeSameException();

            return Task.CompletedTask;
        }

        public Task SeriesNotFound(Series series)
        {
            if (series == null) throw new SeriesNotFoundException();
            return Task.CompletedTask;
        }
    }
}
