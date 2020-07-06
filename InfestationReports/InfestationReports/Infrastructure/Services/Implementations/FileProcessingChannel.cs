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

        public FileProcessingChannel()
        {
            _channel = Channel.CreateUnbounded<IFormFile>();
        }

        public async Task SetAsync(IFormFile file)
        {
            await _channel.Writer.WriteAsync(file);
        }

        public IAsyncEnumerable<IFormFile> GetAllFilesAsync()
        {
            return _channel.Reader.ReadAllAsync();
        }

        public void Set(IFormFile file)
        {
            _channel.Writer.TryWrite(file);
            
        }
    }
}