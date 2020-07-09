using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InfestationReports.Infrastructure.Configuration;
using InfestationReports.Infrastructure.Services.Implementations;
using InfestationReports.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InfestationReports.Infrastructure.BackgroundServiceFolder
{
    public class UploadFileService : BackgroundService
    {
        private IFileProcessingChannel FileProcessingChannel { get; }
        private IServiceProvider ScopeFactory { get; }

        public UploadFileService(IFileProcessingChannel fileProcessingChannel, IServiceProvider scopeFactory)
        {
            FileProcessingChannel = fileProcessingChannel;
            ScopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = ScopeFactory.CreateScope();

            var restClient = scope.ServiceProvider.GetRequiredService<IExampleRestClient>();

            // на цьому місці програма вилітає. Але тільки в режимі дебагу. 
            await Task.Run(() =>
            {
                foreach (var file in FileProcessingChannel.GetAllFiles())
                {
                    restClient.UploadFile(file);
                }
            }, stoppingToken);
        }
       
    }
}