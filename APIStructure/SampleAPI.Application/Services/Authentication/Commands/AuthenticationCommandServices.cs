using SampleAPI.Application.Common.Errors;
using SampleAPI.Application.Common.Interfaces;
using SampleAPI.Application.Services.Authentication.Common;
using SampleAPI.Domain.Entities;

namespace SampleAPI.Application.Services.Authentication.Commands
{
    public class AuthenticationCommandServices : IAuthenticationCommandServices
    {
        private readonly IJWTTokenGenerator _jWTTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationCommandServices(IJWTTokenGenerator jWTTokenGenerator, IUserRepository userRepository)
        {
            _jWTTokenGenerator = jWTTokenGenerator;
            _userRepository = userRepository;
        }

        AuthenticationResult IAuthenticationCommandServices.Register(string Email, string Password, string FirstName, string lastName)
        {
            // check if user there
            if (_userRepository.GetUserByMail(Email) is not null)
                throw new DuplicateMailException();

            // create user
            var user = new User() { Email = Email, FirstName = FirstName, Password = Password, LastName = lastName };
            _userRepository.Add(user);


            // create Tocken
            var tocken = _jWTTokenGenerator.GenerateToken(user.Id, FirstName, lastName);
            return new AuthenticationResult(user.Id, user.FirstName, user.FirstName, user.Email, tocken);
        }
    }
}
