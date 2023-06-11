namespace NoteIt.Auth.Identity;
internal class KeyNormalizer : ILookupNormalizer
{
    public string? NormalizeEmail(string? email) => email;

    public string? NormalizeName(string? name) => name;
}
