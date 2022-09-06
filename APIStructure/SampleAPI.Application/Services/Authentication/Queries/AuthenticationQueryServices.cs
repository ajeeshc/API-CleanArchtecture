using SampleAPI.Application.Common.Errors;
using SampleAPI.Application.Common.Interfaces;
using SampleAPI.Application.Services.Authentication.Common;
using SampleAPI.Domain.Entities;

namespace SampleAPI.Application.Services.Authentication.Queries
{
    public class AuthenticationQueryServices : IAuthenticationQueryServices
    {
        private readonly IJWTTokenGenerator _jWTTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationQueryServices(IJWTTokenGenerator jWTTokenGenerator, IUserRepository userRepository)
        {
            _jWTTokenGenerator = jWTTokenGenerator;
            _userRepository = userRepository;
        }

        AuthenticationResult IAuthenticationQueryServices.Login(string Email, string Password)
        {
            if (_userRepository.GetUserByMail(Email) is not User user)
                throw new Exception("invalid user");
            if (user.Password != Password)
                throw new Exception("invalid passowrd");

            var tocken = _jWTTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

            return new AuthenticationResult(user.Id, user.FirstName, user.LastName, user.Email, tocken);
        }

     
    }
}
