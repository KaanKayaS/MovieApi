using MovieApi.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Exceptions
{
    public class SeriesNotFoundException : BaseException
    {
        public SeriesNotFoundException(): base("Böyle bir dizi bulunamadı.") { }
    }
}
