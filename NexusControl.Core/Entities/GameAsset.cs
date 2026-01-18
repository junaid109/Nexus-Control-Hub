using System;
using System.ComponentModel.DataAnnotations;

namespace NexusControl.Core.Entities
{
    public class GameAsset
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(20)]
        public string AssetType { get; set; } = string.Empty; // e.g., '3DModel', 'Audio'

        public string BlobUrl { get; set; } = string.Empty;

        [MaxLength(64)]
        public string Hash { get; set; } = string.Empty;

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}

