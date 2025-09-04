using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcBuildApp.Data
{
    public class ComponentSpecs : BaseEntity
    {
        public int Id { get; set; }
        
        // CPU Specifications
        public int? Cores { get; set; }
        public int? Threads { get; set; }
        
        [Column(TypeName = "decimal(5,2)")]
        public decimal? BaseClock { get; set; }
        
        [Column(TypeName = "decimal(5,2)")]
        public decimal? BoostClock { get; set; }
        
        public int? TDP { get; set; }
        
        [StringLength(50)]
        public string? Socket { get; set; }
        
        // GPU Specifications
        public int? VRAM { get; set; }
        
        [Column(TypeName = "decimal(8,2)")]
        public decimal? CoreClock { get; set; }
        
        [Column(TypeName = "decimal(8,2)")]
        public decimal? MemoryBandwidth { get; set; }
        
        // RAM Specifications
        public int? Speed { get; set; }
        public int? Capacity { get; set; }
        
        [StringLength(20)]
        public string? Latency { get; set; }
        
        // Storage Specifications
        public int? ReadSpeed { get; set; }
        public int? WriteSpeed { get; set; }
        public int? IOPS { get; set; }
        public int? StorageCapacity { get; set; }
        
        // PSU Specifications
        public int? Wattage { get; set; }
        
        [StringLength(20)]
        public string? EfficiencyRating { get; set; }
        
        // Motherboard Specifications
        [StringLength(50)]
        public string? Chipset { get; set; }
        
        public int? MaxRAM { get; set; }
        public int? RAMSlots { get; set; }
        
        // Foreign Key
        public int ComponentId { get; set; }
    }
}