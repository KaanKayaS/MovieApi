using MovieApi.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Exceptions
{
    public class InvalidUserException : BaseException
    {
        public InvalidUserException(): base("Geçersiz Kullancı") { }
    }
}
