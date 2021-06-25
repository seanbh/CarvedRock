using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CarvedRock.API.Middleware
{
    public class ExceptionHandling
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public ExceptionHandling(RequestDelegate next, ILogger<ExceptionHandling> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            if(ex is ApplicationException)
            {
                logger.LogWarning($"{ex.Message}: {ex.StackTrace}");
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return context.Response.WriteAsJsonAsync(new { ex.Message });
            }
            else
            {
                logger.LogError($"{ex.Message}: {ex.StackTrace}");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return context.Response.WriteAsJsonAsync(new { Message = "Something went wrong" });
            }
        }
    }
}
