using FluentValidation;
using MovieApi.Application.Features.Commands.MovieCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Validator
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(x => x.Name)
                 .NotEmpty()
                 .WithMessage("Film adı boş olamaz.");

            RuleFor(x => x.MoviePlot)
                .NotEmpty()
                .WithMessage("Film konusu boş olamaz.");

            RuleFor(x => x.PublicationDate)
                .NotEmpty()
                .WithMessage("Yayın tarihi boş olamaz.");

            RuleFor(x => x.ImdbPoint)
                .InclusiveBetween(0, 10)
                .WithMessage("IMDB puanı 0 ile 10 arasında olmalıdır.");

            RuleFor(x => x.CountryId)
                .GreaterThan(0)
                .WithMessage("Geçerli bir ülke seçilmelidir.");

            RuleFor(x => x.Image)
                .NotEmpty()
                .WithMessage("Film görseli boş olamaz.");

            RuleFor(x => x.Duration)
                .NotEmpty()
                .WithMessage("Film süresi boş olmamalıdır.");

            RuleFor(x => x.GenreIds)
                .NotEmpty()
                .WithMessage("En az bir tür seçilmelidir.");

            RuleForEach(x => x.GenreIds)
                .GreaterThan(0)
                .WithMessage("Geçerli tür ID'leri olmalıdır.");

            RuleFor(x => x.ActorIds)
                .NotEmpty()
                .WithMessage("En az bir oyuncu seçilmelidir.");

            RuleForEach(x => x.ActorIds)
                .GreaterThan(0)
                .WithMessage("Geçerli oyuncu ID'leri olmalıdır.");
        }
    }
}
