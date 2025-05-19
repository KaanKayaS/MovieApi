using FluentValidation;
using MovieApi.Application.Features.Commands.RevokeCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Validator
{
    public class RevokeCommandValidator : AbstractValidator<RevokeCommand>
    {
        public RevokeCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();
        }
    }
}
