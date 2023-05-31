namespace NoteIt.Domain.Common;
public abstract class AuditableEntityBase : EntityBase
{
    public DateTime Created { get; set; }
    public DateTime? Modified { get; set; }
}
