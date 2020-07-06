using System;
using System.Threading;
using System.Threading.Tasks;
using InfestationReports.Infrastructure.Configuration;
using InfestationReports.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
namespace InfestationReports.Infrastructure.BackgroundServiceFolder
{
    public class LoadFileService : BackgroundService
    {
        private readonly IMemoryCache _cache;

        private readonly IServiceScopeFactory _scopeFactory;

        // private readonly IExampleRestClient _restClient;
        private readonly InfestationConfiguration _infestationConfiguration;

        public LoadFileService(IMemoryCache cache, IExampleRestClient restClient,
            IOptions<InfestationConfiguration> options, IServiceScopeFactory scopeFactory)
        {
            _cache = cache;
            _scopeFactory = scopeFactory;
            // _restClient = restClient;
            _infestationConfiguration = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken cancellationToken)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var restClient = 
                    scope.ServiceProvider
                        .GetRequiredService<IExampleRestClient>();
                
                while (!cancellationToken.IsCancellationRequested)
                {
                    var image = restClient.GetFile();

                    if (image != null)
                    {
                        var cacheKey = HelperHostedServiceClass.CacheKey;

                        var expirationTime = TimeSpan.FromMinutes(_infestationConfiguration.ExpirationCacheTime);
                        var entryOptions = new MemoryCacheEntryOptions
                        {
                            SlidingExpiration = expirationTime
                        };

                        _cache.Set(cacheKey, image, entryOptions);
                    }

                    await Task.Delay(_infestationConfiguration.DelayTime, cancellationToken);
                }
            }
        }
    }
}