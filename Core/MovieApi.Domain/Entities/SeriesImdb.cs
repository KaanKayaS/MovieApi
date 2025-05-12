using MovieApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class SeriesImdb : EntityBase
    {
        public int SeriesId { get; set; }
        public int Season { get; set; }
        public double ImdbPoint { get; set; }

        public Series Series { get; set; }
    }
}
