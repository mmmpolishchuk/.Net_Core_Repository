using System;
using System.Threading.Channels;
using System.Threading.Tasks;
using InfestationReports.Infrastructure.BackgroundServiceFolder;
using InfestationReports.Infrastructure.Configuration;
using InfestationReports.Infrastructure.Services.Interfaces;
using InfestationReports.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace InfestationReports.Controllers
{
    public class EarthController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly IExampleRestClient _restClient;
        private readonly InfestationConfiguration _infestationConfiguration;
        private IFileProcessingChannel _fileProcessingChannel;

        public EarthController(IMemoryCache cache, IExampleRestClient restClient,
            IOptions<InfestationConfiguration> infestationConfiguration, IFileProcessingChannel fileProcessingChannel)
        {
            _cache = cache;
            _restClient = restClient;
            _fileProcessingChannel = fileProcessingChannel;
            _infestationConfiguration = infestationConfiguration.Value;
        }

        [AllowAnonymous]
        public FileContentResult Image()
        {
            var cacheKey = HelperHostedServiceClass.CacheKey;

            var image = _cache.Get<byte[]>(cacheKey);
            if (image == null)
            {
                image = _restClient.GetFile();
                _cache.Set(cacheKey, image);
            }

            return new FileContentResult(image, _infestationConfiguration.ContentType);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Upload([FromForm]EarthUploadViewModel uploadFile)
        {
            if (uploadFile.File?.Length > 0)
            {
                 _fileProcessingChannel.Set(uploadFile.File);

                uploadFile.Stage = UploadStage.Completed;
                uploadFile.File = null;
            }
               
            return View(uploadFile);
        }
    }
}