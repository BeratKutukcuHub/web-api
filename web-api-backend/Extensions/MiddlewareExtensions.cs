using System.Net;
using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Services.Contract;

namespace Backend.Extensions;
public static class MiddlewareExtensions
{
    public static void ConfigureExtensionsHandler(this WebApplication application,
    ILoggerService logger)
    {
        application.UseExceptionHandler(opt =>
        {
            opt.Run(async appError =>
            {
                appError.Response.ContentType = "application/json";
                var context = appError.Features.Get<IExceptionHandlerFeature>();
                if (context != null)
                {
                    appError.Response.StatusCode = context.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    };
                    
                    logger.LogError($"Something went wrong {context.Error.Message}");
                    await appError.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = appError.Response.StatusCode,
                        Message = $"Bir sorun oluştu : {context.Error.Message}"
                    }.ToString());
                }
            });
        });
    }
} 