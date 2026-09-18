using System.ComponentModel.DataAnnotations;

namespace PerioperativeAssistant.Models
{
    public class ResourceType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string Variant { get; set; } = string.Empty;

        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        public bool IsReusable { get; set; }

        public bool RequiresReprocessing { get; set; }

        public bool IsConsumable { get; set; }

        public bool IsActive { get; set; } = true;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<ResourcePrediction> ResourcePredictions { get; set; }
            = new List<ResourcePrediction>();

        public ICollection<ResourceUseEvent> ResourceUseEvents { get; set; }
            = new List<ResourceUseEvent>();
			
		public ICollection<ResourceInventory> ResourceInventories { get; set; }
			= new List<ResourceInventory>();
    }
}