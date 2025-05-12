using MovieApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class Series : EntityBase
    {
        public string Name { get; set; }
        public string SeriesPlot { get; set; }
        public DateTime PublicationDate { get; set; }
        public int DirectorId { get; set; }
        public int CountryId { get; set; }
        public string Image { get; set; }
        public int SeasonCount { get; set; }
        public Country Country { get; set; }
        public Director Director { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<SeriesImdb> SeriesImdbs { get; set; }

    }
}
