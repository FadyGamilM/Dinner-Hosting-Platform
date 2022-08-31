namespace DinnerHostingPlatform.Application.Services.Authentication
{
   public interface IAuthenticationService
   {
      /*
      we can't recieve the RegisterRequest or the LoginRequest as an input to our services
      because they are defined in the cotnracts (presentation) layer, and we here at the application layer 
      */
      // Login service
      AuthenticationResult Login (
         string email,
         string password
      );
      // register service
      AuthenticationResult Register (
         string firstname,
         string lastname,
         string email,
         string password
      );
   }
}