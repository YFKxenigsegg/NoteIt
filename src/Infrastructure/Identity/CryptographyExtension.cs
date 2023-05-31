namespace NoteIt.Infrastructure.Identity;
public static class CryptographyExtension
{
    public static string CreateHash(string input)
    {
        const int _workFactor = 12;
        var hash = BCrypt.Net.BCrypt.HashPassword(input, _workFactor);
        return hash;
    }

    public static bool Verify(string input, string hash) =>
        BCrypt.Net.BCrypt.Verify(input, hash);
}
