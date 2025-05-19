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
    public class UpdateSeriesCommentCommandHandler : BaseHandler, IRequestHandler<UpdateSeriesCommentCommand, Unit>
    {
        private readonly CommentRules commentRules;
        private readonly AuthRules authRules;

        public UpdateSeriesCommentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor,
            CommentRules commentRules, AuthRules authRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.commentRules = commentRules;
            this.authRules = authRules;
        }

        public async Task<Unit> Handle(UpdateSeriesCommentCommand request, CancellationToken cancellationToken)
        {
            CommentSeries comment = await unitOfWork.GetReadRepository<CommentSeries>().GetAsync(x => x.Id == request.Id);
            await commentRules.CommentNotFoundSeries(comment);

            string? userStringId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid UserId = await authRules.InvalidUser(userStringId);

            await commentRules.ThisCommentDoesNotBelongToYouSeries(UserId, comment);

            comment.Content = request.Content;

            await unitOfWork.GetWriteRepository<CommentSeries>().UpdateAsync(comment);

            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
