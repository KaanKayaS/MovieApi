using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.Commands.LoginCommands;
using MovieApi.Application.Features.Commands.RefreshTokenCommands;
using MovieApi.Application.Features.Commands.RegisterCommands;
using MovieApi.Application.Features.Commands.RevokeCommands;
using MovieApi.Domain.Entities;
using System.Net;

namespace MovieApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly UserManager<User> userManager;

        public AuthController(IMediator mediator, UserManager<User> userManager)
        {
            this.mediator = mediator;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            await mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created,"Lütfen Giriş yapmadan önce Emailinize gelen maili onaylayın!");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdminAccount(CreateAdminCommand command)
        {
            await mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var response = await mediator.Send(command);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommand command)
        {
            var response = await mediator.Send(command);
            return StatusCode(StatusCodes.Status200OK, response);
        }


        [HttpPost]
        public async Task<IActionResult> Revoke(RevokeCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RevokeAll()
        {
            await mediator.Send(new RevokeAllCommand());
            return Ok();
        }
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return BadRequest("Kullanıcı bulunamadı");

            var decodedToken = WebUtility.UrlDecode(token).Trim();

            var result = await userManager.ConfirmEmailAsync(user, decodedToken);

            if (result.Succeeded)
                return Ok("Email başarıyla onaylandı.");
            else
                return BadRequest("Email onaylama başarısız.");
        }


    }
}
