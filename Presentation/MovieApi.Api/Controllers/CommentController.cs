using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.Commands.CommentCommands;

namespace MovieApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator mediator;

        public CommentController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCommentForMovie(CreateMovieCommentCommand command)
        {
            await mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCommentForSeries(CreateSeriesCommentCommand command)
        {
            await mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateCommentForMovies(UpdateMovieCommentCommand command)
        {
            await mediator.Send(command);
            return Ok("Yorum başarıyla güncellendi");
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateCommentForSeries(UpdateSeriesCommentCommand command)
        {
            await mediator.Send(command);
            return Ok("Yorum başarıyla güncellendi");
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> RemovecommentForMovies(int id)
        {
            await mediator.Send(new RemoveMovieCommentCommand(id));
            return Ok("Yorum Başarıyla silindi");
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> RemovecommentForSeries(int id)
        {
            await mediator.Send(new RemoveSeriesCommentCommand(id));
            return Ok("Yorum Başarıyla silindi");
        }
    }
}
