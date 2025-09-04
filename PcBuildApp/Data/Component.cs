using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcBuildApp.Data
{
    public class Component : BaseEntity
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        
        [StringLength(100)]
        public string? Model { get; set; }
        
        [StringLength(1000)]
        public string? Description { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        
        [StringLength(200)]
        public string? ImageUrl { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public bool IsInStock { get; set; } = true;
        
        public int StockQuantity { get; set; } = 0;
        
        public int? TDP { get; set; }
        
        // Foreign Keys
        public int ManufacturerId { get; set; }
        public int CategoryId { get; set; }
    }
}