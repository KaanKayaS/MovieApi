using MovieApi.Application.Bases;
using MovieApi.Application.Features.Exceptions;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Rules
{
    public class CommentRules : BaseRules
    {
        public Task CommentNotFoundMovie(CommentMovie comment)
        {
            if (comment == null) throw new CommentNotFoundException();
            return Task.CompletedTask;
        }

        public Task CommentNotFoundSeries(CommentSeries comment)
        {
            if (comment == null) throw new CommentNotFoundException();
            return Task.CompletedTask;
        }

        public Task ThisCommentDoesNotBelongToYou(Guid userId, CommentMovie CommentMovie)
        {
            if (CommentMovie.UserId != userId) throw new ThisCommentDoesNotBelongToYouException();
            return Task.CompletedTask;
        }

        public Task ThisCommentDoesNotBelongToYouSeries(Guid userId, CommentSeries comment)
        {
            if (comment.UserId != userId) throw new ThisCommentDoesNotBelongToYouException();
            return Task.CompletedTask;
        }
    }
}
