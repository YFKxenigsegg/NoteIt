namespace NoteIt.Domain.Entities;
public class User : IdentityUser
{
    public required DateTime Created { get; set; }
    public DateTime? Modified { get; set; }
    public DateTime? LastAccess { get; set; }
}
