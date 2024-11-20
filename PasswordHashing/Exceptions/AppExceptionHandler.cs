using Microsoft.AspNetCore.Diagnostics;
using PasswordHashing.Models;
using System.ComponentModel.DataAnnotations;

namespace PasswordHashing.Exceptions
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var response = new ErrorResponse();
            if (exception is UserNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.Title = "Wrong input";
                response.ExceptionMessage = exception.Message;
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Title = "Somthing went wrong";
                response.ExceptionMessage = exception.Message;
            }
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
