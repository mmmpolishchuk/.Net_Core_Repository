using Microsoft.AspNetCore.Http;

namespace InfestationReports.Infrastructure.Services.Interfaces
{
    public interface IExampleRestClient
    {
        byte[] GetFile();
        void UploadFile(IFormFile file);
    }
}