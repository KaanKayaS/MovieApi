using FluentValidation;
using MovieApi.Application.Features.Commands.CommentCommands;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Validator
{
    public class CreateMovieCommentCommandValidator : AbstractValidator<CreateMovieCommentCommand>
    {
        public CreateMovieCommentCommandValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .MinimumLength(4)
                .WithName("Yorum");
        }
    }
}
