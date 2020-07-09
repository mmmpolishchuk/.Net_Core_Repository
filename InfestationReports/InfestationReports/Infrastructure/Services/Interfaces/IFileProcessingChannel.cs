using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfestationReports.Infrastructure.Services.Interfaces
{
    public interface IFileProcessingChannel
    {
        void Set(IFormFile file);
        IEnumerable<IFormFile> GetAllFiles();
    }
}