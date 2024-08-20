using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Project.Exceptions
{
    public class CustomException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var response = context.HttpContext.Response;

            if (exception is StudentIdNotExistException)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(new { Message = exception.Message });
            }
            else
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new JsonResult(new { Message = "An unexpected error occurred.", Details = exception.Message });
            }

            context.ExceptionHandled = true;
        }
    }
}
