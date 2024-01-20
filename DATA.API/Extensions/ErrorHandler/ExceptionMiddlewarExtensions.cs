using Core.API.Response;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Data.API.Extensions.ErrorHandler
{
    public static class ExceptionMiddlewarExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication  app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    //context.Response.StatusCode = 500;
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if(errorFeature is not null)
                    {
                        var ex = errorFeature.Error;

                        ErrorDto error = null;

                        if (ex is NotFoundException)
                        {
                            context.Response.StatusCode = StatusCodes.Status404NotFound;
                            error = new ErrorDto(ex.Message, true);
                        }
                        else
                        {
                            error = new ErrorDto(ex.Message, false);
                        }

                        var response = ResponseDto<Response>.Fail(error, context.Response.StatusCode);

                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            });
        }
    }
}
