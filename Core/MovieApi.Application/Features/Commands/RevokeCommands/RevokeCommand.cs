﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Commands.RevokeCommands
{
    public class RevokeCommand : IRequest<Unit>
    {
        public string Email { get; set; }
    }
}
