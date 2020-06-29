using System;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Twilio.TwiML.Voice;
using Task = System.Threading.Tasks.Task;

namespace InfestationReports.Infrastructure.Middlewares
{
    public class WriteConsoleMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly string _param;

        public WriteConsoleMiddleware(RequestDelegate requestDelegate, string param)
        {
            _requestDelegate = requestDelegate;
            _param = param;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.Write(_param);
            await _requestDelegate(context);
        }
    }
}