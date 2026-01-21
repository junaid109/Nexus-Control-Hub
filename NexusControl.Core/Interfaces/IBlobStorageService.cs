using System.IO;
using System.Threading.Tasks;

namespace NexusControl.Core.Interfaces
{
    public interface IBlobStorageService
    {
        Task<string> UploadAssetAsync(Stream stream, string fileName, string containerName);
        Task DeleteAssetAsync(string blobUrl);
    }
}
