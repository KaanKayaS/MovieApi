using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MovieApi.Application.Bases;
using MovieApi.Application.Features.Commands.RegisterCommands;
using MovieApi.Application.Features.Rules;
using MovieApi.Application.Interfaces.UnitOfWorks;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Handlers.RegisterHandlers
{
    public class CreateAdminCommandHandler : BaseHandler, IRequestHandler<CreateAdminCommand, Unit>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public CreateAdminCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, AuthRules authRules,
            UserManager<User> userManager, RoleManager<Role> roleManager) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<Unit> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            User? usertest = await userManager.FindByEmailAsync(request.Email);
            await authRules.UserShouldNotBeExist(usertest);

            User user = mapper.Map<User>(request);

            user.UserName = request.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();  // milisaniyelik işlemler için


            IdentityResult result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                IEnumerable<string> roles = ["user", "admin"];

                foreach (var roleName in roles)
                {
                    var roleExist = await roleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        await roleManager.CreateAsync(new Role
                        {
                            Id = Guid.NewGuid(),
                            Name = roleName,
                            NormalizedName = roleName.ToUpper(),
                            ConcurrencyStamp = Guid.NewGuid().ToString()
                        });
                    }
                }

                await userManager.AddToRolesAsync(user, roles);
            }

            return Unit.Value;
        }
    }
}
