using MovieApi.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Exceptions
{
    public class SeriesNameMustNotBeSameException: BaseException
    {
        public SeriesNameMustNotBeSameException() : base("Bu isimde bir dizi zaten var."){ }
       
    }
}
