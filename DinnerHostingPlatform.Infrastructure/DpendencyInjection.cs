using Microsoft.Extensions.DependencyInjection;
using DinnerHostingPlatform.Infrastructure.Authentication;
using DinnerHostingPlatform.Application.Common.Interfaces.Authentication;
namespace DinnerHostingPlatform.Infrastructure
{
   public static class DependencyInjection
   {
      public static IServiceCollection AddInfrastructureLayerDependencies(this IServiceCollection services)
      {
         //! Inject the jwt token generator service to be utilized by other services
         services.AddScoped<IJwtTokenGenerator, jwtTokenGenerator>();
         return services;
      }
   }
}
 