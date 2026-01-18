using Microsoft.EntityFrameworkCore;
using NexusControl.Core.Entities;

namespace NexusControl.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FeatureFlag> FeatureFlags { get; set; }
        public DbSet<GameAsset> GameAssets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure FeatureFlag
            modelBuilder.Entity<FeatureFlag>(entity =>
            {
                entity.HasIndex(e => e.Key).IsUnique();
                
                // Explictly map to jsonb type for PostgreSQL
                entity.Property(e => e.RulesJson).HasColumnType("jsonb");
            });

            // Configure GameAsset
            modelBuilder.Entity<GameAsset>(entity =>
            {
                entity.Property(e => e.UploadedAt).HasDefaultValueSql("NOW()");
            });
        }
    }
}

