using System;
using System.Threading;
using System.Threading.Tasks;
using InfestationReports.Infrastructure.Services.Implementations;
using InfestationReports.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InfestationReports.Infrastructure.BackgroundServiceFolder
{
    public class UploadFileService : BackgroundService
    {
        private readonly FileProcessingChannel _fileProcessingChannel;

        private readonly IServiceScopeFactory _scopeFactory;
        // private readonly IExampleRestClient _restClient;

        public UploadFileService(FileProcessingChannel fileProcessingChannel, IExampleRestClient restClient,
            IServiceScopeFactory scopeFactory)
        {
            _fileProcessingChannel = fileProcessingChannel;
            // _restClient = restClient;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                await foreach (var file in _fileProcessingChannel.GetAllFilesAsync().WithCancellation(stoppingToken))
                {
                    var restClient =
                        scope.ServiceProvider
                            .GetRequiredService<IExampleRestClient>();
                    
                    restClient.UploadFile(file);
                }
            }
        }
    }
}