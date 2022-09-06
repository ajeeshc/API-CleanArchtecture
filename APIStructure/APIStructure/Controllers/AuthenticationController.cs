using Microsoft.AspNetCore.Mvc;
using SampleAPI.Contracts.Authentication;
using APIStructure.Filters;
using SampleAPI.Application.Services.Authentication.Commands;
using SampleAPI.Application.Services.Authentication.Queries;

namespace APIStructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
  
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticationQueryServices _authenticationQueryService;
        private readonly IAuthenticationCommandServices _authenticationCommandService;

        public AuthenticationController(IAuthenticationQueryServices authenticationQueryService,IAuthenticationCommandServices authenticationCommandServices)
        {
            _authenticationQueryService = authenticationQueryService;
            _authenticationCommandService = authenticationCommandServices;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var result = _authenticationCommandService.Register(request.Email, request.Password, request.FirstName,request.LastName);
            var response = new AuthenticationResponse(
                result.Id,
                result.FirstName,
                result.LastName,
                result.Email,
                result.Tocken
               );
            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var result = _authenticationQueryService.Login(request.Email, request.Password);
            var response = new AuthenticationResponse(
                 result.Id,
                 result.FirstName,
                 result.LastName,
                 result.Email,
                 result.Tocken
                );
            return Ok(response);
        }
    }
}
