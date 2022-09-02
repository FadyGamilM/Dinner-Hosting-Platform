using DinnerHostingPlatform.Domain.Entities;

namespace DinnerHostingPlatform.Application.Common.Interfaces.Authentication
{
   public interface IJwtTokenGenerator
   {
      string GenerateToken(User user);
   }
}