using FluentValidation;
using MovieApi.Application.Features.Commands.CommentCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Validator
{
    public class CreateSeriesCommentCommandValidator : AbstractValidator<CreateSeriesCommentCommand>
    {
        public CreateSeriesCommentCommandValidator()
        {
            RuleFor(x => x.Content)
               .NotEmpty()
               .MinimumLength(4)
               .WithName("Yorum");
        }
    }
}
