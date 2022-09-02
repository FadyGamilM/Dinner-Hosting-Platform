using System.Text;
using DinnerHostingPlatform.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DinnerHostingPlatform.Infrastructure.Authentication
{
   public class jwtTokenGenerator : IJwtTokenGenerator
   {
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
            expires: DateTime.Now.AddDays(1),
            claims: Claims,
            signingCredentials: SigningCredentials
         );
         return new JwtSecurityTokenHandler().WriteToken(securityToken);
      }
   }
}