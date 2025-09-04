using System.ComponentModel.DataAnnotations;
using PcBuildApp.Enums;

namespace PcBuildApp.Data
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        public ComponentType ComponentType { get; set; }
        
        public bool IsActive { get; set; } = true;
    }
}