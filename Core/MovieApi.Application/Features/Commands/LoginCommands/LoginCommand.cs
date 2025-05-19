using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using MovieApi.Application.Features.Results.LoginResults;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Commands.LoginCommands
{
    public class LoginCommand : IRequest<LoginCommandResult>
    {
        [DefaultValue("kaan@info")]
        public string Email { get; set; } 

        [DefaultValue("123456")]
        public string Password { get; set; } 
    }
}
