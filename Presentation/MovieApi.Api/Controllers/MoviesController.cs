using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.Commands.MovieCommands;
using MovieApi.Application.Features.Queries.MovieQueries;
using MovieApi.Application.Features.Results.MovieResults;

namespace MovieApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator mediator;

        public MoviesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovie()
        {
            var values = await mediator.Send(new GetAllMoviesQuery());
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetLatestTop5Movie()
        {
            var values = await mediator.Send(new GetLatestTop5MovieQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
        {
            await mediator.Send(command);
            return Ok("Film Başarıyla oluşturuldu");
        }
    }
}
