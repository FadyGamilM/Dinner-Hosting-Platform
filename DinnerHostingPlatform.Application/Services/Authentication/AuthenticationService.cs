using DinnerHostingPlatform.Application.Common.Interfaces.Authentication;
namespace DinnerHostingPlatform.Application.Services.Authentication
{
   public class AuthenticationService : IAuthenticationService
   {
      private readonly IJwtTokenGenerator _jwtTokenGenerator;
      public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
      {
         this._jwtTokenGenerator = jwtTokenGenerator;
      }
      public AuthenticationResult Login(string email, string password)
      {
         return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            email,
            "Token"
         );
      }

      public AuthenticationResult Register(string firstname, string lastname, string email, string password)
      {
         /* STEPS : 
            1) Check if this user already exists
            2) Create a user (Generate unique ID)
            3) Create JWT token
         */
         // [2]
         var userID = Guid.NewGuid();
         // [3]
         var token = this._jwtTokenGenerator.GenerateToken(userID, firstname, lastname);
         return new AuthenticationResult(
            userID,
            firstname,
            lastname,
            email,
            token
         );      
      }
   }
}