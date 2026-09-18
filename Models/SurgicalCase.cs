using System.ComponentModel.DataAnnotations;

namespace PerioperativeAssistant.Models
{
    public class SurgicalCase
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CaseNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string Location { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Service { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string ProcedureType { get; set; } = string.Empty;

        [StringLength(100)]
        public string ProcedureCode { get; set; } = string.Empty;

        [StringLength(200)]
        public string ProcedureCodeSystem { get; set; } = string.Empty;

        [Required]
        public DateTime ScheduledStart { get; set; }

        public int ScheduledDurationMinutes { get; set; }

        public DateTime? ActualStart { get; set; }

        public DateTime? ActualEnd { get; set; }

        public int? ActualDurationMinutes { get; set; }

        [Required]
        [StringLength(50)]
        public string AnesthesiaType { get; set; } = string.Empty;

        [StringLength(20)]
        public string Status { get; set; } = "Scheduled";

        [StringLength(500)]
        public string Notes { get; set; } = string.Empty;

        public bool IsSynthetic { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<ResourcePrediction> ResourcePredictions { get; set; }
            = new List<ResourcePrediction>();

        public ICollection<ResourceUseEvent> ResourceUseEvents { get; set; }
            = new List<ResourceUseEvent>();
    }
}