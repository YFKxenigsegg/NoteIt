using Note.Domain.Common;

namespace Note.Domain.Entities;
public class Note : AuditableEntityBase
{
    public string Name { get; set; } = default!;
    public string Url { get; set; } = default!;
}
