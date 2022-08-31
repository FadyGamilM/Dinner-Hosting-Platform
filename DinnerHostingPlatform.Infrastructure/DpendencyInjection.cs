using Microsoft.Extensions.DependencyInjection;
namespace DinnerHostingPlatform.Infrastructure
{
   public static class DependencyInjection
   {
      public static IServiceCollection AddInfrastructureLayerDependencies(this IServiceCollection services)
      {
         return services;
      }
   }
}