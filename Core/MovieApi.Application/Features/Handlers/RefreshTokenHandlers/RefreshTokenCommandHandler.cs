using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MovieApi.Application.Bases;
using MovieApi.Application.Features.Commands.RefreshTokenCommands;
using MovieApi.Application.Features.Results.RefreshTokenResults;
using MovieApi.Application.Features.Rules;
using MovieApi.Application.Interfaces.Tokens;
using MovieApi.Application.Interfaces.UnitOfWorks;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Handlers.RefreshTokenHandlers
{
    public class RefreshTokenCommandHandler : BaseHandler, IRequestHandler<RefreshTokenCommand, RefreshTokenCommandResult>
    {

        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly ITokenService tokenService;
        private readonly RefreshTokenRules refreshTokenRules;

        public RefreshTokenCommandHandler(AuthRules authRules, UserManager<User> userManager,
            RoleManager<Role> roleManager, IMapper mapper, IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor, ITokenService tokenService, RefreshTokenRules refreshTokenRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.tokenService = tokenService;
            this.refreshTokenRules = refreshTokenRules;
        }

        public async Task<RefreshTokenCommandResult> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string email = principal.FindFirstValue(ClaimTypes.Email);

            var user = await userManager.FindByNameAsync(email);
            var roles = await userManager.GetRolesAsync(user);

            await refreshTokenRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryTime);

            JwtSecurityToken newAccessToken = await tokenService.CreateToken(user, roles);
            string NewRefreshToken = tokenService.GenerateRefreshToken();

            user.RefreshToken = NewRefreshToken;
            await userManager.UpdateAsync(user);

            return new RefreshTokenCommandResult
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = NewRefreshToken
            };
        }
    }
}
