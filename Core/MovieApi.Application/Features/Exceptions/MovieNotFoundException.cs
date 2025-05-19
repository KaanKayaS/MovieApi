using MovieApi.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Exceptions
{
    public class MovieNotFoundException : BaseException
    {
        public MovieNotFoundException(): base("Böyle bir film bulunamadı.") { }
    }
}
