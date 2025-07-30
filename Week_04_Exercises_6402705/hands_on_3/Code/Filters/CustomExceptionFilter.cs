using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace MyWebApiApp.Filters // ✅ updated namespace
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(new
            {
                Message = "A custom error occurred.",
                Error = context.Exception.Message
            })
            {
                StatusCode = 500
            };
        }
    }
}
