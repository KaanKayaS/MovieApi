using FluentValidation;
using MovieApi.Application.Features.Commands.CommentCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Validator
{
    public class UpdateSeriesCommentCommandValidator : AbstractValidator<UpdateSeriesCommentCommand>
    {
        public UpdateSeriesCommentCommandValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Yorum içeriği boş olamaz")
                .MinimumLength(4)
                .WithName("Yorum");
        }
    }
}
