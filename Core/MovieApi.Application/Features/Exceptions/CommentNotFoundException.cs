using MovieApi.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Exceptions
{
    public class CommentNotFoundException : BaseException
    {
        public CommentNotFoundException() : base("Böyle bir yorum bulunamadı."){ }
    }
}
