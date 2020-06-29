using System;
using System.Collections;
using System.Net.Http;
using System.Threading.Tasks;
using InfestationReports.Controllers;
using InfestationReports.Infrastructure.Configuration;
using InfestationReports.Infrastructure.Services.Implementations;
using InfestationReports.Infrastructure.Services.Interfaces;
using InfestationReports.Models;
using InfestationReports.Models.Repositories.HumanRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils.Messaging;

namespace InfestationReports.Infrastructure.Middlewares
{
    public class RequestInfoMiddleware
    {
        public string Sender { get; set; }
        public string Params { get; set; }
        public DateTime Date { get; set; }
        public bool CancelSending { get; set; }
        public InfestationConfiguration InfestationConfiguration { get; }
        public IMessageService MessageService { get; }
        public RequestDelegate Next { get; }

        public RequestInfoMiddleware(RequestDelegate next, IMessageService messageService,
            IOptions<InfestationConfiguration> options)
        {
            Next = next;
            MessageService = messageService;
            InfestationConfiguration = options.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            CancelSending = InfestationConfiguration.CancelSending;
            if (CancelSending == false)
            {
                Sender = context.Request.Host.ToString();
                Params = context.Request.GetEncodedPathAndQuery() + " " + context.Request.Method + " " + context.Request.Protocol;
                Date = DateTime.Now;

                MessageService.SendMessage("Request info",
                    $"<p>Client's host: {Sender}</p></br>" +
                    $"<p>Request parameters: {Params}</p></br>" +
                    $"<p>Request date: {Date}</p></br>",
                    SenderType.Email);
            }

            await Next(context);
        }
    }
}