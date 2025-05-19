using MediatR;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Commands.CommentCommands
{
    public class CreateMovieCommentCommand : IRequest<Unit>
    {
        public string Content { get; set; }
        public int MovieId { get; set; }
    }
}
