using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using VmsInform.Common.Exceptions;

namespace VmsInformWeb.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ForbiddenException:
                context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                    break;
                case InvalidOperationException:
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                case NotFoundException:
                context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;
                case ValidationException vex:
                    {
                        var errors = vex.Errors
                            .GroupBy(a => a.PropertyName)
                            .ToDictionary(a => a.Key, a => a.Select(x => x.ErrorMessage).ToArray());


                        var details = new ValidationProblemDetails();

                        foreach (var error in errors)
                        {
                            details.Errors.Add(error);
                        }

                    }
                    break;
            }
        }
    }
}
