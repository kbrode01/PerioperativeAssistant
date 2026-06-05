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

        // This represents the table in the database
        public DbSet<SurgicalCase> SurgicalCases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optional: Configure table name and properties
            modelBuilder.Entity<SurgicalCase>()
                .Property(c => c.CaseNumber)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<SurgicalCase>()
                .Property(c => c.PatientId)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<SurgicalCase>()
                .Property(c => c.SurgeonName)
                .HasMaxLength(100);

            modelBuilder.Entity<SurgicalCase>()
                .Property(c => c.AnesthesiologistName)
                .HasMaxLength(100);

            modelBuilder.Entity<SurgicalCase>()
                .Property(c => c.CrnaName)
                .HasMaxLength(100);

            modelBuilder.Entity<SurgicalCase>()
                .Property(c => c.AnesTechName)
                .HasMaxLength(100);

            modelBuilder.Entity<SurgicalCase>()
                .Property(c => c.ProcedureType)
                .HasMaxLength(150);

            modelBuilder.Entity<SurgicalCase>()
                .Property(c => c.AnesthesiaType)
                .HasMaxLength(50);

            modelBuilder.Entity<SurgicalCase>()
                .Property(c => c.Status)
                .HasMaxLength(20);

            modelBuilder.Entity<SurgicalCase>()
                .Property(c => c.Notes)
                .HasMaxLength(500);
        }
    }
}