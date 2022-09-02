using DinnerHostingPlatform.Application.Common.Interfaces.Authentication;
using DinnerHostingPlatform.Application.Common.Interfaces.Persistence;
using DinnerHostingPlatform.Domain.Entities;

namespace DinnerHostingPlatform.Application.Services.Authentication
{
   public class AuthenticationService : IAuthenticationService
   {
      private readonly IJwtTokenGenerator _jwtTokenGenerator;
      private readonly IUserRepository _userRepository;
      public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
      {
         _jwtTokenGenerator = jwtTokenGenerator;
         _userRepository = userRepository;
      }
      public AuthenticationResult Login(string email, string password)
      {
         /* STEPS : 
            1) Check if this user exists or not
            2) If user exists, check if the password is correct or not
            3) If password is correct, generate a JWT token and return it
         */
         //! [1]
         // var user = this._userRepository.GetUserByEmail(email);
         if (this._userRepository.GetUserByEmail(email) is not User user)
         {
            throw new Exception("This user is not registered");
         }
         //! [2]
         if (user.Password != password)
         {
            throw new Exception("Password is incorrect");
         }
         //! [3]
         var token = this._jwtTokenGenerator.GenerateToken(user);
         return new AuthenticationResult(
            user,
            token
         );
      }

      public AuthenticationResult Register(string firstname, string lastname, string email, string password)
      {
         /* STEPS : 
            1) Check if this user already exists
            2) Create a user (Generate unique ID) & Persist to the DB
            3) Create JWT token
         */
         //! [1]
         if (this._userRepository.GetUserByEmail(email) is not null)
         {
            throw new Exception("User already exists");
         }
         //! [2]
         // create the new user
         var user = new User{
            FirstName = firstname,
            LastName = lastname,
            Email = email,
            Password = password
         };
         // persist the user to the database
         this._userRepository.AddUser(user);
         //! [3]
         var token = this._jwtTokenGenerator.GenerateToken(user);
         return new AuthenticationResult(
            user,
            token
         );      
      }
   }
}