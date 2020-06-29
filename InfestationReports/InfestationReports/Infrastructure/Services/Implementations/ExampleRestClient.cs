using InfestationReports.Infrastructure.Services.Interfaces;
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
    }
}