using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DinnerHostingPlatform.API.Filters
{
      public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
      {
         public override void OnException(ExceptionContext context)
         {
            var exception = context.Exception;
            // what we will return to the client
            var result = new ObjectResult(new { error = "Error occurred while processing your request" })
            {
               StatusCode = 500
            };   
            context.Result = result;
            context.ExceptionHandled = true;
         }
      }
}