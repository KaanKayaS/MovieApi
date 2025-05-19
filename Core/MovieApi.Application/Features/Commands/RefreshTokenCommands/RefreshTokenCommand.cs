using MediatR;
using MovieApi.Application.Features.Results.RefreshTokenResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Commands.RefreshTokenCommands
{
    public class RefreshTokenCommand : IRequest<RefreshTokenCommandResult>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
