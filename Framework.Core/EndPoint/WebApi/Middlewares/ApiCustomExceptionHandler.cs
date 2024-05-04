using System.Net;
using Common.Application.Validation;
using Framework.Core.Domain.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Framework.Core.EndPoint.WebApi.Middlewares;

public static class ApiCustomExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseApiCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ApiCustomExceptionHandlerMiddleware>();
    }
}

public class ApiCustomExceptionHandlerMiddleware(
    RequestDelegate next,
    IHostingEnvironment env,
    ILogger<ApiCustomExceptionHandlerMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        string message = null;
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
        AppStatusCode apiStatusCode = AppStatusCode.ServerError;

        try
        {
            await next(context);
        }
        catch (InvalidDomainDataException exception)
        {
            logger.LogError(exception, exception.Message);
            apiStatusCode = AppStatusCode.LogicError;
            SetErrorMessage(exception);
            await WriteToResponseAsync();
        }
        catch (InvalidCommandException exception)
        {
            logger.LogError(exception, exception.Message);
            httpStatusCode = HttpStatusCode.BadRequest;
            SetErrorMessage(exception);
            await WriteToResponseAsync();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);

            SetErrorMessage(exception);
            await WriteToResponseAsync();
        }

        void SetErrorMessage(Exception exception)
        {
            message = exception.Message;
            if (env.IsDevelopment())
            {
                var dic = new Dictionary<string, string>
                {
                    ["Exception"] = exception.Message,
                    ["StackTrace"] = exception.StackTrace,
                };
                if (exception.InnerException != null)
                {
                    dic.Add("InnerException.Exception", exception.InnerException.Message);
                    dic.Add("InnerException.StackTrace", exception.InnerException.StackTrace);
                }

                message = JsonConvert.SerializeObject(dic);
            }
        }
        async Task WriteToResponseAsync()
        {
            if (context.Response.HasStarted)
                throw new InvalidOperationException("The response has already started, the http status code middleware will not be executed.");

            var result = new ApiResult()
            {
                IsSuccess = false,
                MetaData = new()
                {
                    AppStatusCode = apiStatusCode,
                    Message = message
                }
            };
            var json = JsonConvert.SerializeObject(result);

            context.Response.StatusCode = (int)httpStatusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
        }
    }
}