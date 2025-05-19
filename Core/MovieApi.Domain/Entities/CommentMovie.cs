using MovieApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class CommentMovie : EntityBase
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public int MovieId { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
