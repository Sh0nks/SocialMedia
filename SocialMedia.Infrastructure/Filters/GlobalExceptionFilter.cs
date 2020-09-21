using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocialMedia.Core.Exceptions;

namespace SocialMedia.Infrastruncture.Filters
{
    public class GlobalExceptionFilter: IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BussinesExecption))
            {
                BussinesExecption execption = (BussinesExecption) context.Exception;

                var error = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = execption.Message
                };

                var json = new
                {
                    errors = new[] {error}
                };
                
                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}