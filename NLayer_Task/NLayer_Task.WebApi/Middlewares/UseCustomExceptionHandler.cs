using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Diagnostics;
using NLayer_Task.Business.Exceptions;
using System.Text.Json;

namespace NLayer_Task.WebApi.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    var exeptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    Exception exeption = exeptionFeature.Error;

                    var statusCode = StatusCodes.Status500InternalServerError;
                    switch (exeption)
                    {
                        case BadRequestException:
                            statusCode = StatusCodes.Status400BadRequest;
                            break;
                        case NotFoundException:
                            statusCode = StatusCodes.Status404NotFound;
                            break;
                        default:
                            break;
                    }
                    var message = exeption.Message;
                    //if (message.Length > 30)
                      //  message = "System Error please try later";
                    context.Response.StatusCode = statusCode;
                    context.Response.ContentType = "application/json";

                    var response = ApiResponse<NoData>.Fail(statusCode, exeption.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });
            });

        }
    }
}
