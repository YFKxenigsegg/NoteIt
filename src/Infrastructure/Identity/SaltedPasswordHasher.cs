using Microsoft.AspNetCore.Identity;
using NoteIt.Domain.Entities;

namespace NoteIt.Infrastructure.Identity;
public class SaltedPasswordHasher : PasswordHasher<User>
{
    private const string _salt = "D98EE44D-DCCE-496E-AAC6-178DA9CC3FA6";

    public override string HashPassword(User user, string password)
        => CryptographyExtension.CreateHash(password + _salt);

    public override PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword) =>
        CryptographyExtension.Verify(providedPassword + _salt, hashedPassword)
            ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
}
