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
        [StringLength(20)]
        public string PatientId { get; set; } = string.Empty;

        [StringLength(100)]
        public string SurgeonName { get; set; } = string.Empty;

        [StringLength(100)]
        public string AnesthesiologistName { get; set; } = string.Empty;

        [StringLength(100)]
        public string CrnaName { get; set; } = string.Empty;

        [StringLength(100)]
        public string AnesTechName { get; set; } = string.Empty;

        public DateTime SurgeryDate { get; set; }

        [StringLength(150)]
        public string ProcedureType { get; set; } = string.Empty;

        [StringLength(50)]
        public string AnesthesiaType { get; set; } = string.Empty;

        [StringLength(20)]
        public string Status { get; set; } = "Scheduled";

        [StringLength(500)]
        public string Notes { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}