using Microsoft.AspNetCore.Identity;
using NoteIt.Application.Abstractions;

namespace NoteIt.UnitTests.Mocks;
internal static class AuthenticationMock
{
    public static Mock<IJwtProvider> GetJwtProviderMock()
    {
        var jwtProvider = new Mock<IJwtProvider>();

        jwtProvider.Setup(x => x.GenerateJwtToken(It.IsAny<ApplicationUser>())).Returns("jwtToken");

        return jwtProvider;
    }

    public static Mock<UserManager<ApplicationUser>> GetUserManagerMock()
    {
        var userPasswordStoreMock = new Mock<IUserPasswordStore<ApplicationUser>>();
        var userManagerMock = new Mock<UserManager<ApplicationUser>>(userPasswordStoreMock.Object, null, null, null, null, null, null, null, null);

        userManagerMock.Object.UserValidators.Add(new UserValidator<ApplicationUser>());
        userManagerMock.Object.PasswordValidators.Add(new PasswordValidator<ApplicationUser>());

        var identityResult = new IdentityResultMock(true);
        userManagerMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(identityResult);
        userManagerMock.Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(true);

        return userManagerMock;
    }
}

internal class IdentityResultMock : IdentityResult
{
    public IdentityResultMock(bool succeeded = false)
    {
        Succeeded = succeeded;
    }
}
