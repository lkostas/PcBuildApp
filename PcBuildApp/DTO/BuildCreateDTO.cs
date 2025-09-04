using System.ComponentModel.DataAnnotations;

namespace PcBuildApp.DTO
{
    public class BuildCreateDTO
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        
        [StringLength(1000)]
        public string? Description { get; set; }

        public int TotalWattage { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsPublic { get; set; } = false;
        public bool IsCompleted { get; set; } = false;
    }
}