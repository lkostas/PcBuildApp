using System.ComponentModel.DataAnnotations;

namespace PcBuildApp.Data
{
    public class Manufacturer : BaseEntity
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        [StringLength(200)]
        public string? Website { get; set; }
        
        [StringLength(200)]
        public string? LogoUrl { get; set; }
        
        public bool IsActive { get; set; } = true;
    }
}