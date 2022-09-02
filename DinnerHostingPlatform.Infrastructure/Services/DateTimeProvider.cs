using DinnerHostingPlatform.Application.Services;
namespace DinnerHostingPlatform.Infrastructure.Services
{
   public class DateTimeProvider : IDateTimeProvider
   {
      public DateTime UtcNow => DateTime.UtcNow;
   }
}