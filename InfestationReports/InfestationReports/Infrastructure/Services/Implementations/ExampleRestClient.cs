using System.IO;
using InfestationReports.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using RestSharp;

namespace InfestationReports.Infrastructure.Services.Implementations
{
    public class ExampleRestClient : IExampleRestClient
    {
        public byte[] GetFile()
        {
            var client = new RestClient("http://localhost:51258");
            var request = new RestRequest("File", Method.GET);
            var result = client.Execute(request).RawBytes;

            return result;
        }

        public void UploadFile(IFormFile file)
        {
            var client = new RestClient("http://localhost:51258");
            var request = new RestRequest("File", Method.POST);

            if (file != null)
            {
                byte[] image = null;
                
                using (var binaryReader = new BinaryReader(file.OpenReadStream()))
                {
                    image = binaryReader.ReadBytes((int) file.Length);
                }

                request.AddJsonBody(image);
                request.AddQueryParameter("fileName", file.FileName);
                client.Execute(request);
            }
        }
    }
}