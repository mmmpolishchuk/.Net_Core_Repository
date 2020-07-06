using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace InfestationReports.Infrastructure.Services.Interfaces
{
    public interface IFileProcessingChannel
    {
        Task SetAsync(IFormFile file);
        IAsyncEnumerable<IFormFile> GetAllFilesAsync();
    }
}