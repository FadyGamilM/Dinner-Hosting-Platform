using Microsoft.Extensions.DependencyInjection;
using DinnerHostingPlatform.Application.Services.Authentication;
namespace DinnerHostingPlatform.Application
{
   public static class DependencyInjection
   {
      public static IServiceCollection AddApplicationLayerDependencies(this IServiceCollection services)
      {
         //! Inject the `AuthenticationService` from the Application Layer as a dependency
         services.AddScoped<IAuthenticationService, AuthenticationService>();
         return services;
      }
   }
}