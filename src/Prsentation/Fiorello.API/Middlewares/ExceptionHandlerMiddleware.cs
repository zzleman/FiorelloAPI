using Fiorello.Application.DTOs.ResponseDTOs;
using Fiorello.Persistance.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Fiorello.API.Middelewares;

public static class ExceptionHandlerMiddeleware
{
    public static IApplicationBuilder UserCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                int StatusCode = (int)HttpStatusCode.InternalServerError;
                string message = "Internal Server Error";

                if (contextFeature is not null)
                {
                    if (contextFeature.Error is IBaseException)
                    {
                        var exception = (IBaseException)contextFeature.Error;
                        StatusCode = exception.StatusCode;
                        message = exception.CustomMessage;
                    }
                }
                context.Response.StatusCode = StatusCode;
                await context.Response.WriteAsJsonAsync(new ExceptionResponseDto(StatusCode, message));
            });
        });
        return app;
    }
}