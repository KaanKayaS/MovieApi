using MovieApi.Application.Bases;
using MovieApi.Application.Exceptions;
using MovieApi.Application.Features.Exceptions;
using MovieApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }

        public Task<Guid> InvalidUser(string stringuserId)
        {
            if (!Guid.TryParse(stringuserId, out Guid userId)) throw new InvalidUserException();
            return Task.FromResult(userId);
        }

        public Task EmailOrPasswordShouldNotBeInvalid(User user, bool checkpassword)
        {
            if (user == null || !checkpassword) throw new EmailOrPasswordShouldNotBeInvalidException();
            return Task.CompletedTask;
        }

        public Task EmailAddressShouldBeValid(User? user)
        {
            if (user == null)
                throw new EmailAddressShouldBeValidException();

            return Task.CompletedTask;
        }
    }
}
