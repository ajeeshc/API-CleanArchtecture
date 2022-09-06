
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SampleAPI.Application.Common.Interfaces;
using SampleAPI.Application.Common.Interfaces.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SampleAPI.Infrastructure.Authentication
{
    public class JWTTockenGenerator : IJWTTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JWTSettings _jWTSettings;
        public JWTTockenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JWTSettings> jetOptions)
        {
            _dateTimeProvider = dateTimeProvider;
            _jWTSettings = jetOptions.Value;
        }

        public string GenerateToken(Guid userID, string firstname, string lastname)
        {
            var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWTSettings.Secret)),
                    SecurityAlgorithms.HmacSha256
                );

            var calims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userID.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstname),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastname),
                new Claim(JwtRegisteredClaimNames.UniqueName, userID.ToString()),
            };

            var s_tocken = new JwtSecurityToken(
                    issuer:_jWTSettings.Issuer,
                    audience:_jWTSettings.Audience,
                    expires: _dateTimeProvider.UtcNow.AddMinutes(_jWTSettings.ExpirationalTimeInMinutes),
                    claims: calims,
                    signingCredentials: signingCredentials
                    );
            return  new JwtSecurityTokenHandler().WriteToken(s_tocken);
        }
    }
}