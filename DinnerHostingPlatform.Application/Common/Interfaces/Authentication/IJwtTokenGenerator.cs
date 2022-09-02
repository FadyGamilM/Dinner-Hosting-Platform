namespace DinnerHostingPlatform.Application.Common.Interfaces.Authentication
{
   public interface IJwtTokenGenerator
   {
      string GenerateToken(Guid userID, string firstName, string lastName);
   }
}