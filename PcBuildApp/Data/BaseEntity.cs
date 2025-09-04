namespace PcBuildApp.Data
{
    public class BaseEntity
    {
        public DateTime InsertedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedAt { get; set; } = null;
    }
}