using DinnerHostingPlatform.Domain.Entities;

namespace DinnerHostingPlatform.Application.Services.Authentication
{
   public record AuthenticationResult
   (
      User user,
      string Token
   );
}