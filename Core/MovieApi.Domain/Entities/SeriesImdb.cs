using MovieApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class SeriesImdb
    {
        public int SeriesId { get; set; }
        public int Season { get; set; }
        public double ImdbPoint { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public Series Series { get; set; }
    }
}
