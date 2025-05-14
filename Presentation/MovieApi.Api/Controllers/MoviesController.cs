using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.Queries.MovieQueries;

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
    }
}
