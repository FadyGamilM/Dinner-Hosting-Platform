using Microsoft.Extensions.DependencyInjection;
using DinnerHostingPlatform.Infrastructure.Authentication;
using DinnerHostingPlatform.Application.Services;
using DinnerHostingPlatform.Application.Common.Interfaces.Authentication;
using DinnerHostingPlatform.Infrastructure.Services;

namespace DinnerHostingPlatform.Infrastructure
{
   public static class DependencyInjection
   {
      public static IServiceCollection AddInfrastructureLayerDependencies(this IServiceCollection services)
      {
         //! Inject the jwt token generator service to be utilized by other services
         services.AddScoped<IJwtTokenGenerator, jwtTokenGenerator>();
         //! Inject the Date Time Provider service to be utilizer later
         services.AddScoped<IDateTimeProvider, DateTimeProvider>();
         return services;
      }
   }
}
 