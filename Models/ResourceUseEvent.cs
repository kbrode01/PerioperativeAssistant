using System.ComponentModel.DataAnnotations;

namespace PerioperativeAssistant.Models
{
    public class ResourceUseEvent
    {
        public int Id { get; set; }

        [Required]
        public int SurgicalCaseId { get; set; }

        public SurgicalCase? SurgicalCase { get; set; }

        [Required]
        public int ResourceTypeId { get; set; }

        public ResourceType? ResourceType { get; set; }

        [Required]
        public DateTime UsedAt { get; set; }

        public int QuantityUsed { get; set; } = 1;

        public DateTime? BecameUnavailableAt { get; set; }

        public DateTime? SentToProcessingAt { get; set; }

        public DateTime? ProcessingStartedAt { get; set; }

        public DateTime? ProcessingCompletedAt { get; set; }

        public DateTime? AvailableAgainAt { get; set; }

        public int? TotalTurnaroundMinutes { get; set; }

        [StringLength(30)]
        public string Status { get; set; } = "Used";

        public bool IsSynthetic { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}