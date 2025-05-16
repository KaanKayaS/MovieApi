using MovieApi.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Exceptions
{
    public class MovieNameMustNotBeSameException : BaseException
    {
        public MovieNameMustNotBeSameException() : base("Bu film adı zaten kullanılmış") { }
      
    }
}
