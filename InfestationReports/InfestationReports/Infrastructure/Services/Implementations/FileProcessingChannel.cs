using System.Collections.Generic;
using System.Threading.Channels;
using System.Threading.Tasks;
using InfestationReports.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InfestationReports.Infrastructure.Services.Implementations
{
    public class FileProcessingChannel : IFileProcessingChannel
    {
        private readonly Channel<IFormFile> _channel;
        private List<IFormFile> Files { get; }

        public FileProcessingChannel()
        {
            _channel = Channel.CreateUnbounded<IFormFile>();
        }
        public IEnumerable<IFormFile> GetAllFiles()
        {
            if ( _channel.Reader.TryRead(out var file))
            {
                Files.Add(file);
            };
            return Files;
        }

        public void Set(IFormFile file)
        {
            _channel.Writer.TryWrite(file);
            
        }
    }
}