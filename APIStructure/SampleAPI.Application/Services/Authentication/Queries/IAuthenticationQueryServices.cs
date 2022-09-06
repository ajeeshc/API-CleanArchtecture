using SampleAPI.Application.Services.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Application.Services.Authentication.Queries
{
    public interface IAuthenticationQueryServices
    {
        AuthenticationResult Login(string Email, string Password);
    }
}
