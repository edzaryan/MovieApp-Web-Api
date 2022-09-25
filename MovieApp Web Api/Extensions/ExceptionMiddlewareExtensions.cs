using Microsoft.AspNetCore.Diagnostics;
using System.Net;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureGlobalExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature != null)
                {
                    await context.Response.WriteAsync(new ErrorDetails
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal Server Error"
                    }.ToString());
                }
            });
        });
    }


    public static void ConfigureGlobalErrorHandler(this IApplicationBuilder app)
    {
        app.UseStatusCodePages(async statusCodeContext =>
        {
            var response = statusCodeContext.HttpContext.Response;
            var path = statusCodeContext.HttpContext.Request.Path;

            response.ContentType = "text/plain; charset=UTF-8";

            if (response.StatusCode == 400)
            {
                await response.WriteAsync($"Path: {path}. Bad Request");
            }
            else if (response.StatusCode == 404)
            {
                await response.WriteAsync($"Resource {path}. Not Found");
            }
            else
            {
                await response.WriteAsync($"Other Error Occured");
            }
        });
    }
}