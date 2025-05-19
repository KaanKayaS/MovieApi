using MovieApi.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Exceptions
{
    public class ThisCommentDoesNotBelongToYouException : BaseException
    {
        public ThisCommentDoesNotBelongToYouException(): base("Bu yorum size ait değil o nedenle  işlem yapamazsınız") { }

    }
}
