namespace NoteIt.Application.Handlers.Roles;
public class RoleInfo : InfoBase, IMapFrom<IdentityRole>
{
    public string Name { get; set; } = default!;
}
