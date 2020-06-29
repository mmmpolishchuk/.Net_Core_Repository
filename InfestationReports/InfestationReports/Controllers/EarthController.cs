using System;
using InfestationReports.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InfestationReports.Controllers
{
    public class EarthController : Controller
    {
        private IMemoryCache _cache;
        private IExampleRestClient _restClient;

        public EarthController(IMemoryCache cache, IExampleRestClient restClient)
        {
            _cache = cache;
            _restClient = restClient;
        }

        [AllowAnonymous]
        public FileContentResult Image()
        
        {
            var cacheKey = $"image_{DateTime.UtcNow:yyyy_MM_dd}";
            var image = _cache.Get<byte[]>(cacheKey);
            if (image == null)
            {
                image = _restClient.GetFile();
                _cache.Set<byte[]>(cacheKey, image);
            }

            return new FileContentResult(image, "image/jpeg");
        }
    }
}