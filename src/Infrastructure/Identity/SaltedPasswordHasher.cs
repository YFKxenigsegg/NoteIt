using Microsoft.AspNetCore.Identity;
using NoteIt.Domain.Entities;

namespace NoteIt.Infrastructure.Identity;
public class SaltedPasswordHasher : PasswordHasher<ApplicationUser>
{
    private const string _salt = "D98EE44D-DCCE-496E-AAC6-178DA9CC3FA6";

    public override string HashPassword(ApplicationUser user, string password)
        => CryptographyExtension.CreateHash(password + _salt);

    public bool Verify(string providedPassword, string hashedPassword)
        => CryptographyExtension.Verify(providedPassword + _salt, hashedPassword);
}
