using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Commands.CommentCommands
{
    public class RemoveMovieCommentCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public RemoveMovieCommentCommand(int id)
        {
            Id = id;
        }
    }
}
