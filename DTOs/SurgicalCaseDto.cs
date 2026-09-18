using System.ComponentModel.DataAnnotations;

namespace PerioperativeAssistant.DTOs
{
    public class SurgicalCaseDto
    {
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

        [Range(1, 1440)]
        public int ScheduledDurationMinutes { get; set; }

        [Required]
        [StringLength(50)]
        public string AnesthesiaType { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Status { get; set; }

        [StringLength(500)]
        public string Notes { get; set; } = string.Empty;

        public bool IsSynthetic { get; set; } = true;
    }
}