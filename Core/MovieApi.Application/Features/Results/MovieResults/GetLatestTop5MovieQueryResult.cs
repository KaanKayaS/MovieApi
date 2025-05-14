using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Results.MovieResults
{
    public class GetLatestTop5MovieQueryResult
    {
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Image { get; set; }
        public double ImdbPoint { get; set; }
    }
}
