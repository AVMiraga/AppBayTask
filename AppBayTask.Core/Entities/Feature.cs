using AppBayTask.Core.Entities.Common;

namespace AppBayTask.Core.Entities
{
    public class Feature : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
