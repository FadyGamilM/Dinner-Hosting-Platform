using System.Text;
using DinnerHostingPlatform.Application.Common.Interfaces.Authentication;
using DinnerHostingPlatform.Application.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DinnerHostingPlatform.Infrastructure.Authentication
{
   public class jwtTokenGenerator : IJwtTokenGenerator
   {
      private readonly IDateTimeProvider _DateTimeProivder;
      public jwtTokenGenerator(IDateTimeProvider DateTimeProvider)
      {
         this._DateTimeProivder = DateTimeProvider;
      }
      public string GenerateToken(Guid userID, string firstName, string lastName)
      {
         var SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
               Encoding.UTF8.GetBytes("super-secret-key")
            ),
            SecurityAlgorithms.HmacSha256
         );
         
         var Claims = new []
         {
            new Claim(JwtRegisteredClaimNames.Sub, userID.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
         };

         var securityToken = new JwtSecurityToken(
            issuer: "DinnerHostingPlatform",
            expires: this._DateTimeProivder.UtcNow.AddMinutes(60),
            claims: Claims,
            signingCredentials: SigningCredentials
         );
         return new JwtSecurityTokenHandler().WriteToken(securityToken);
      }
   }
}