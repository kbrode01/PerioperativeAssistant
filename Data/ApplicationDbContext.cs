using Microsoft.EntityFrameworkCore;
using PerioperativeAssistant.Models;

namespace PerioperativeAssistant.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // =====================================================
        // Database Tables
        // =====================================================

        public DbSet<SurgicalCase> SurgicalCases { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<ResourcePrediction> ResourcePredictions { get; set; }
        public DbSet<ResourceUseEvent> ResourceUseEvents { get; set; }
        public DbSet<ResourceInventory> ResourceInventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =================================================
            // SurgicalCase
            // =================================================

            modelBuilder.Entity<SurgicalCase>()
                .HasIndex(c => c.CaseNumber)
                .IsUnique();

            modelBuilder.Entity<SurgicalCase>()
                .HasIndex(c => c.ScheduledStart);

            modelBuilder.Entity<SurgicalCase>()
                .HasIndex(c => c.Location);

            modelBuilder.Entity<SurgicalCase>()
                .HasIndex(c => c.Service);

            // =================================================
            // ResourceType
            // =================================================

            modelBuilder.Entity<ResourceType>()
                .HasIndex(r => new
                {
                    r.Name,
                    r.Variant
                })
                .IsUnique();

            // =================================================
            // ResourcePrediction
            // =================================================

            modelBuilder.Entity<ResourcePrediction>()
                .HasOne(rp => rp.SurgicalCase)
                .WithMany(sc => sc.ResourcePredictions)
                .HasForeignKey(rp => rp.SurgicalCaseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ResourcePrediction>()
                .HasOne(rp => rp.ResourceType)
                .WithMany(rt => rt.ResourcePredictions)
                .HasForeignKey(rp => rp.ResourceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ResourcePrediction>()
                .HasIndex(rp => rp.PredictedUseTime);

            modelBuilder.Entity<ResourcePrediction>()
                .HasIndex(rp => new
                {
                    rp.ResourceTypeId,
                    rp.PredictedUseTime
                });

            // =================================================
            // ResourceUseEvent
            // =================================================

            modelBuilder.Entity<ResourceUseEvent>()
                .HasOne(rue => rue.SurgicalCase)
                .WithMany(sc => sc.ResourceUseEvents)
                .HasForeignKey(rue => rue.SurgicalCaseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ResourceUseEvent>()
                .HasOne(rue => rue.ResourceType)
                .WithMany(rt => rt.ResourceUseEvents)
                .HasForeignKey(rue => rue.ResourceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ResourceUseEvent>()
                .HasIndex(rue => rue.UsedAt);

            modelBuilder.Entity<ResourceUseEvent>()
                .HasIndex(rue => new
                {
                    rue.ResourceTypeId,
                    rue.UsedAt
                });

            modelBuilder.Entity<ResourceUseEvent>()
                .HasIndex(rue => new
                {
                    rue.ResourceTypeId,
                    rue.AvailableAgainAt
                });

            // =================================================
            // ResourceInventory
            // =================================================

            modelBuilder.Entity<ResourceInventory>()
                .HasOne(ri => ri.ResourceType)
                .WithMany(rt => rt.ResourceInventories)
                .HasForeignKey(ri => ri.ResourceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ResourceInventory>()
                .HasIndex(ri => new
                {
                    ri.ResourceTypeId,
                    ri.Location
                })
                .IsUnique();
        }
    }
}