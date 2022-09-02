using System.Text;
using DinnerHostingPlatform.Application.Common.Interfaces.Authentication;
using DinnerHostingPlatform.Application.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using DinnerHostingPlatform.Domain.Entities;

namespace DinnerHostingPlatform.Infrastructure.Authentication
{
   public class jwtTokenGenerator : IJwtTokenGenerator
   {
      private readonly IDateTimeProvider _DateTimeProivder;
      private readonly JwtSettings _jwtoptions;
      public jwtTokenGenerator(IDateTimeProvider DateTimeProvider, IOptions<JwtSettings> jwtoptions)
      {
         this._DateTimeProivder = DateTimeProvider;
         this._jwtoptions = jwtoptions.Value;
      }
      public string GenerateToken(User user)
      {
         var SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
               Encoding.UTF8.GetBytes(this._jwtoptions.Secret)
            ),
            SecurityAlgorithms.HmacSha256
         );
         
         var Claims = new []
         {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
      };

         var securityToken = new JwtSecurityToken(
            issuer: this._jwtoptions.Issuer,
            audience: this._jwtoptions.Audience,
            expires: this._DateTimeProivder.UtcNow.AddMinutes(this._jwtoptions.ExpiryMinutes),
            claims: Claims,
            signingCredentials: SigningCredentials
         );
         return new JwtSecurityTokenHandler().WriteToken(securityToken);
      }
   }
}