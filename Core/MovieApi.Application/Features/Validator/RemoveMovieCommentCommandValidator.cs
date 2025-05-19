using FluentValidation;
using MovieApi.Application.Features.Commands.CommentCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Validator
{
    public class RemoveMovieCommentCommandValidator : AbstractValidator<RemoveMovieCommentCommand>
    {
        public RemoveMovieCommentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id değeri boş olamaz")
                .GreaterThan(0);
        }
    }
}
