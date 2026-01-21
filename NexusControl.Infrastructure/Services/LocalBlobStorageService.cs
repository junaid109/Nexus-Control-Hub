using NexusControl.Core.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NexusControl.Infrastructure.Services
{
    public class LocalBlobStorageService : IBlobStorageService
    {
        private readonly string _webRootPath;

        public LocalBlobStorageService(string webRootPath)
        {
            _webRootPath = webRootPath;
        }

        public async Task<string> UploadAssetAsync(Stream stream, string fileName, string containerName)
        {
            // Simulate Cloud Storage by saving to wwwroot/uploads
            var uploadsFolder = Path.Combine(_webRootPath, "uploads", containerName);
            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await stream.CopyToAsync(fileStream);
            }

            // Return relative URL for browser access
            return $"/uploads/{containerName}/{uniqueFileName}";
        }

        public Task DeleteAssetAsync(string blobUrl)
        {
            // In a real app we would parse the URL and delete the file
            // For this mock, we'll just return completed
            return Task.CompletedTask;
        }
    }
}
