using MovieApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class Director : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public ICollection<Series> Series { get; set; }
    }
}
