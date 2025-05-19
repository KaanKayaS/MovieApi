using FluentValidation;
using MovieApi.Application.Features.Commands.RefreshTokenCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Validator
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty();

            RuleFor(x => x.AccessToken)
               .NotEmpty();
        }
    }
}
