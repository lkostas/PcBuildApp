using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcBuildApp.Data
{
    public class Build : BaseEntity
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        
        [StringLength(1000)]
        public string? Description { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice { get; set; } = 0;
        
        public int TotalWattage { get; set; } = 0;
        
        public bool IsPublic { get; set; } = false;
        
        public bool IsCompleted { get; set; } = false;
        
        // Foreign Key
        public int UserId { get; set; }
    }
}