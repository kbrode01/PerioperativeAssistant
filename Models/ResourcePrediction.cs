using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerioperativeAssistant.Models
{
    public class ResourcePrediction
    {
        public int Id { get; set; }

        [Required]
        public int SurgicalCaseId { get; set; }

        public SurgicalCase? SurgicalCase { get; set; }

        [Required]
        public int ResourceTypeId { get; set; }

        public ResourceType? ResourceType { get; set; }

        [Column(TypeName = "decimal(5,4)")]
        public decimal Probability { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal ExpectedQuantity { get; set; }

        public DateTime PredictedUseTime { get; set; }

        [StringLength(50)]
        public string ModelVersion { get; set; } = string.Empty;

        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

        public bool IsSynthetic { get; set; } = true;
    }
}