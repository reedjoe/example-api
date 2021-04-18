using System;
using System.Net;
using Example.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilters.Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            HttpStatusCode statusCode;

            switch (context.Exception)
            {
                case EntityBadRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case EntityNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.Result = new JsonResult(new
            {
                error = new[] { context.Exception.Message },
                stackTrace = context.Exception.StackTrace
            });
        }
    }
}
