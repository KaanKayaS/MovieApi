using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Bases;
using MovieApi.Application.Features.Commands.CommentCommands;
using MovieApi.Application.Features.Rules;
using MovieApi.Application.Interfaces.UnitOfWorks;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Handlers.CommentHandlers
{
    public class CreateMovieCommentCommandHandler : BaseHandler, IRequestHandler<CreateMovieCommentCommand, Unit>
    {
        private readonly MovieRules movieRules;
        private readonly AuthRules authRules;

        public CreateMovieCommentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor,
            MovieRules movieRules, AuthRules authRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.movieRules = movieRules;
            this.authRules = authRules;
        }

        public async Task<Unit> Handle(CreateMovieCommentCommand request, CancellationToken cancellationToken)
        {
            var userIdString = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Guid userId = await authRules.InvalidUser(userIdString);
           
            Movie movie = await unitOfWork.GetReadRepository<Movie>().GetAsync(x => x.Id == request.MovieId);
            await movieRules.MovieNotFound(movie);

            await unitOfWork.GetWriteRepository<CommentMovie>().AddAsync(new CommentMovie
            {
                Content = request.Content,
                MovieId = request.MovieId,
                UserId = userId,
                CreatedDate = DateTime.UtcNow.AddHours(3),
                IsDeleted = false
            });

            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
