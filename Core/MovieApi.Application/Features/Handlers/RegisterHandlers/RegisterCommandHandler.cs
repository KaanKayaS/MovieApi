using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MovieApi.Application.Bases;
using MovieApi.Application.DTOs;
using MovieApi.Application.Features.Commands.RegisterCommands;
using MovieApi.Application.Features.Rules;
using MovieApi.Application.Interfaces.Events;
using MovieApi.Application.Interfaces.UnitOfWorks;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Handlers.RegisterHandlers
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommand, Unit>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IMessagePublisher messagePublisher;

        public RegisterCommandHandler(AuthRules authRules, UserManager<User> userManager,
            RoleManager<Role> roleManager , IMapper mapper, IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor, IMessagePublisher messagePublisher) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.messagePublisher = messagePublisher;
        }
        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            User? usertest = await userManager.FindByEmailAsync(request.Email);
            await authRules.UserShouldNotBeExist(usertest);

            User user = mapper.Map<User>(request);

            user.UserName = request.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();  // milisaniyelik işlemler için


            IdentityResult result = await userManager.CreateAsync(user , request.Password);
            if (result.Succeeded) 
            {
                if (!await roleManager.RoleExistsAsync("user"))
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    });
                await userManager.AddToRoleAsync(user, "user");

                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var encodedToken = WebUtility.UrlEncode(token);

                var emailMessage = new EmailConfirmationMessage
                {
                    Email = user.Email,
                    Token = encodedToken
                };

                await messagePublisher.PublishAsync(emailMessage);

            }

            return Unit.Value;

        }
    }
}
