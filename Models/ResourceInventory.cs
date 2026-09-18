using System.ComponentModel.DataAnnotations;

namespace PerioperativeAssistant.Models
{
    public class ResourceInventory
    {
        public int Id { get; set; }

        [Required]
        public int ResourceTypeId { get; set; }

        public ResourceType? ResourceType { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; } = string.Empty;

        public int TotalQuantity { get; set; }

        public int AvailableQuantity { get; set; }

        public int UnavailableQuantity { get; set; }

        public int? MinimumDesiredQuantity { get; set; }

        public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;

        public bool IsSynthetic { get; set; } = true;
    }
}