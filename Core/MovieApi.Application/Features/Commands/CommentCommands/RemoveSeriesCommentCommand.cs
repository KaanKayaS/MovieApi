using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Commands.CommentCommands
{
    public class RemoveSeriesCommentCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public RemoveSeriesCommentCommand(int id)
        {
            Id = id;
        }
    }
}
