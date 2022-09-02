using Microsoft.Extensions.DependencyInjection;
using DinnerHostingPlatform.Infrastructure.Authentication;
using DinnerHostingPlatform.Application.Services;
using DinnerHostingPlatform.Application.Common.Interfaces.Authentication;
using DinnerHostingPlatform.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using DinnerHostingPlatform.Application.Common.Interfaces.Persistence;
using DinnerHostingPlatform.Infrastructure.Persistence;

namespace DinnerHostingPlatform.Infrastructure
{
   public static class DependencyInjection
   {
      public static IServiceCollection AddInfrastructureLayerDependencies(
         this IServiceCollection services,
         ConfigurationManager configuration)
         
      {
         services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
         //! Inject the jwt token generator service to be utilized by other services
         services.AddScoped<IJwtTokenGenerator, jwtTokenGenerator>();
         //! Inject the Date Time Provider service to be utilizer later
         services.AddScoped<IDateTimeProvider, DateTimeProvider>();
         //! Configure the concrete implementation of the USER REPOSITORY SERVICE
         services.AddScoped<IUserRepository, UserRepository>();
         return services;
      }
   }
}
 