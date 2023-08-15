using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EcomProductManager.Filters
{
    public class GlobalExceptionFilter:IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult("An unexpected error occurred.")
            {
                StatusCode = 500,
                Value = new
                {
                    Error = "An unexpected error occurred. Please try again later.",
                    Details = context.Exception.Message,
                    InnerException = context.Exception.InnerException.Message
                }
            };

            context.ExceptionHandled = true;
        }
    }
}
