using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusControl.Core.Entities
{
    public class FeatureFlag
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string Key { get; set; } = string.Empty;

        public bool IsEnabled { get; set; }

        [Column(TypeName = "jsonb")]
        public string? RulesJson { get; set; } 
        
        // Alternatively, we can map a strongly typed object. 
        // For now, keeping it as string or JsonDocument is simplest for "JSONB" raw awareness, 
        // but typically we'd use a property.
        // Let's use a class for better practice if we add the Npgsql dependencies to Core, but 
        // Core should stay clean. 
        // So I will just use string for the entity and handle serialization in the service/repo
        // OR better yet, just use string and let EF Core handle it if configured. 
        // Actually, Npgsql supports mapping POCOs to JSONB directly. 
        // But that requires Npgsql reference in Core.
        // To keep Core clean of Npgsql dependency, we often use `string` or a primitive.
        // However, the user asked for "Robust JSONB", implying they want to use its power.
        // I'll stick to string for the Core entity definition for maximum portability, 
        // or I can add a dedicated object if I want to be fancy.
        // Let's stick to simple string for the JSON content to avoid infrastructure leakage into Core
        // unless I add the System.Text.Json reference which is standard.
    }
}

