using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    public class FileController
    {
        [HttpGet("File")]
        public FileContentResult GetFile()
        {
            var fileBytes = System.IO.File.ReadAllBytes("Earth.jpg");
            return new FileContentResult(fileBytes, "image/jpeg");
        }

        [HttpPost("File")]
        public void UploadFile([FromBody] string file, [FromQuery]string fileName, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            var fileBytes = File.ReadAllBytes(file);
            var filePath = Path.Combine(webHostEnvironment.WebRootPath, fileName);
            File.WriteAllBytes(filePath, fileBytes);

        }
    }
}