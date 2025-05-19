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
    public class CreateSeriesCommentCommandHandler : BaseHandler, IRequestHandler<CreateSeriesCommentCommand, Unit>
    {
        private readonly SeriesRules seriesRules;
        private readonly AuthRules authRules;

        public CreateSeriesCommentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor,
            SeriesRules seriesRules, AuthRules authRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.seriesRules = seriesRules;
            this.authRules = authRules;
        }

        public async Task<Unit> Handle(CreateSeriesCommentCommand request, CancellationToken cancellationToken)
        {
            var userIdString = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Guid userId = await authRules.InvalidUser(userIdString);

            Series series = await unitOfWork.GetReadRepository<Series>().GetAsync(x => x.Id == request.SeriesId);
            await seriesRules.SeriesNotFound(series);

            await unitOfWork.GetWriteRepository<CommentSeries>().AddAsync(new CommentSeries
            {
                Content = request.Content,
                SeriesId = request.SeriesId,
                UserId = userId,
                CreatedDate = DateTime.UtcNow.AddHours(3),
                IsDeleted = false
            });

            await unitOfWork.SaveAsync();

            return Unit.Value;

        }
    }
}
