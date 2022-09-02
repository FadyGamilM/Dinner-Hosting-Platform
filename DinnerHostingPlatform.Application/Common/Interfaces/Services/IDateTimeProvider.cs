namespace DinnerHostingPlatform.Application.Services
{
   public interface IDateTimeProvider
   {
      DateTime UtcNow  {get; }
   }
}