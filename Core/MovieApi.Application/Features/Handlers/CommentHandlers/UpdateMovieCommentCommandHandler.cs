using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    public class UpdateMovieCommentCommandHandler : BaseHandler, IRequestHandler<UpdateMovieCommentCommand, Unit>
    {
        private readonly CommentRules commentRules;
        private readonly AuthRules authRules;

        public UpdateMovieCommentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor,
            CommentRules commentRules, AuthRules authRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.commentRules = commentRules;
            this.authRules = authRules;
        }

        public async Task<Unit> Handle(UpdateMovieCommentCommand request, CancellationToken cancellationToken)
        {
            CommentMovie commentMovie = await unitOfWork.GetReadRepository<CommentMovie>().GetAsync(x => x.Id == request.Id);
            await commentRules.CommentNotFoundMovie(commentMovie);

            var userIdString = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid userId = await authRules.InvalidUser(userIdString);

            await commentRules.ThisCommentDoesNotBelongToYou(userId, commentMovie);

            commentMovie.Content = request.Content;

            await unitOfWork.GetWriteRepository<CommentMovie>().UpdateAsync(commentMovie);

            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
