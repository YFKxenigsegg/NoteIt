namespace NoteIt.Domain.Entities;
public class Note : AuditableEntityBase
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}
