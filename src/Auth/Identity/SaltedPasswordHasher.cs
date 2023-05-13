﻿using Microsoft.AspNetCore.Identity;
using Note.Infrastructure.Identity;

namespace Note.Auth.Identity;
public class SaltedPasswordHasher : PasswordHasher<UserInfo>
{
    private const string _salt = "D98EE44D-DCCE-496E-AAC6-178DA9CC3FA6";

    public override string HashPassword(UserInfo user, string password)
        => CryptographyExtension.CreateHash(password + _salt);

    public bool Verify(string providedPassword, string hashedPassword)
        => CryptographyExtension.Verify(providedPassword + _salt, hashedPassword);
}
