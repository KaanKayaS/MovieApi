using FluentValidation;
using MovieApi.Application.Features.Commands.CommentCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Validator
{
    public class UpdateMovieCommentCommandValidator : AbstractValidator<UpdateMovieCommentCommand>
    {
        public UpdateMovieCommentCommandValidator()
        {
            RuleFor(x => x.Content)
             .NotEmpty()
             .MinimumLength(4)
             .WithName("Yorum");
        }
    }
}
