using NoteIt.Domain.Common;

namespace NoteIt.Domain.Entities;
public class Note : AuditableEntityBase
{
    public string Name { get; set; } = default!;
    public string Url { get; set; } = default!;
}
