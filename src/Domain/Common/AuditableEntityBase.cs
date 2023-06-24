namespace NoteIt.Domain.Common;
public abstract class AuditableEntityBase : EntityBase
{
    public required DateTime Created { get; set; }
    public DateTime? Modified { get; set; }
}
