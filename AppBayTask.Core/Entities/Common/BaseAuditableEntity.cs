namespace AppBayTask.Core.Entities.Common
{
    public class BaseAuditableEntity : BaseEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
