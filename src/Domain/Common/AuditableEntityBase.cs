namespace Note.Domain.Common;
public class AuditableEntityBase : EntityBase
{
    public DateTime Created { get; set; }
    public DateTime? Modified { get; set; }
}
