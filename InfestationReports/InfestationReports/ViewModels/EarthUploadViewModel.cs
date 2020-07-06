using Microsoft.AspNetCore.Http;

namespace InfestationReports.ViewModels
{
    public class EarthUploadViewModel
    {
        public IFormFile File { get; set; }
        public UploadStage Stage { get; set; }
    }

    public enum UploadStage
    {
        Upload, 
        Completed
    }
}