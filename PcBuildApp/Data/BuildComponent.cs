using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcBuildApp.Data
{
    public class BuildComponent : BaseEntity
    {
        public int Id { get; set; }
        
        public int Quantity { get; set; } = 1;
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal PriceAtTime { get; set; }
        
        // Foreign Keys
        public int BuildId { get; set; }
        public int ComponentId { get; set; }
    }
}