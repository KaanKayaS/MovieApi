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
    public class RemoveSeriesCommentCommandHandler : BaseHandler, IRequestHandler<RemoveSeriesCommentCommand, Unit>
    {
        private readonly CommentRules commentRules;
        private readonly AuthRules authRules;

        public RemoveSeriesCommentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor,
            CommentRules commentRules, AuthRules authRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.commentRules = commentRules;
            this.authRules = authRules;
        }

        public async Task<Unit> Handle(RemoveSeriesCommentCommand request, CancellationToken cancellationToken)
        {
            CommentSeries commentSeries = await unitOfWork.GetReadRepository<CommentSeries>().GetAsync(x => x.Id == request.Id);
            await commentRules.CommentNotFoundSeries(commentSeries);

            Guid UserId = await authRules.InvalidUser(userId);

            await commentRules.ThisCommentDoesNotBelongToYouSeries(UserId, commentSeries);

            await unitOfWork.GetWriteRepository<CommentSeries>().HardDeleteAsync(commentSeries);

            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
