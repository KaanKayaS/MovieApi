using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Results.RefreshTokenResults
{
    public class RefreshTokenCommandResult
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
