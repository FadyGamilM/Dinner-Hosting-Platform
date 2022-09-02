using Microsoft.AspNetCore.Mvc;
using DinnerHostingPlatform.Contracts.Authentication;
using DinnerHostingPlatform.Application.Services.Authentication;
namespace DinnerHostingPlatform.API.Controllers
{
   [ApiController]
   [Route("auth")]
   public class AuthenticationController : ControllerBase
   {
      private readonly IAuthenticationService _authService;
      public AuthenticationController(IAuthenticationService authService)
      {
         this._authService = authService; 
      }

      [HttpPost("register")]
      public IActionResult Register([FromBody] RegisterRequest request)
      {
         var authResult = this._authService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
         );
         var response = new AuthenticationResponse(
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
            authResult.Token
         );
         return Ok(response);
      }

      [HttpPost("login")]
      public IActionResult Login([FromBody] LoginRequest request)
      {
         var authResult = this._authService.Login(
            request.Email,
            request.Password
         );
         var response = new AuthenticationResponse(
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
            authResult.Token
         );
         return Ok(response);   
      }
   }
}