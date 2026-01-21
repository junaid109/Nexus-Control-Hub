using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexusControl.Core.Entities;
using NexusControl.Core.Interfaces;
using NexusControl.Infrastructure.Data;

namespace NexusControl.Web.Controllers
{
    public class AssetsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBlobStorageService _blobService;

        public AssetsController(ApplicationDbContext context, IBlobStorageService blobService)
        {
            _context = context;
            _blobService = blobService;
        }

        public async Task<IActionResult> Index()
        {
            var assets = await _context.GameAssets
                .OrderByDescending(a => a.UploadedAt)
                .ToListAsync();
            return View(assets);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile? file, string assetType)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file selected.");

            // Calculate SHA256 Hash
            string fileHash;
            using (var stream = file.OpenReadStream())
            using (var sha = SHA256.Create())
            {
                var hashBytes = sha.ComputeHash(stream);
                fileHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                stream.Position = 0; // Reset for upload
            }

            // Upload to Blob (Local/Azure)
            string blobUrl;
            using (var stream = file.OpenReadStream())
            {
                blobUrl = await _blobService.UploadAssetAsync(stream, file.FileName, "game-assets");
            }

            // Save Metadata
            var asset = new GameAsset
            {
                AssetType = assetType ?? "Unknown",
                BlobUrl = blobUrl,
                Hash = fileHash
            };

            _context.GameAssets.Add(asset);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
