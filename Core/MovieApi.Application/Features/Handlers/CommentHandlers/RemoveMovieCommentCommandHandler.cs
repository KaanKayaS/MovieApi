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
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Handlers.CommentHandlers
{
    public class RemoveMovieCommentCommandHandler : BaseHandler, IRequestHandler<RemoveMovieCommentCommand, Unit>
    {
        private readonly CommentRules commentRules;
        private readonly AuthRules authRules;

        public RemoveMovieCommentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor,
            CommentRules commentRules, AuthRules authRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.commentRules = commentRules;
            this.authRules = authRules;
        }

        public async Task<Unit> Handle(RemoveMovieCommentCommand request, CancellationToken cancellationToken)
        {
            CommentMovie commentMovie = await unitOfWork.GetReadRepository<CommentMovie>().GetAsync(x => x.Id == request.Id);
            await commentRules.CommentNotFoundMovie(commentMovie);

            Guid UserId = await authRules.InvalidUser(userId);

            await commentRules.ThisCommentDoesNotBelongToYou(UserId, commentMovie);

            await unitOfWork.GetWriteRepository<CommentMovie>().HardDeleteAsync(commentMovie);

            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
