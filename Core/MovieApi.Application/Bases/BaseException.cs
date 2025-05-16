using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Bases
{
    public class BaseException : ApplicationException
    {
        public BaseException()
        {
        }

        public BaseException(string message) : base(message) { }
    }
}
