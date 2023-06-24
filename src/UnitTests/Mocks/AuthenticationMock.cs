using Microsoft.AspNetCore.Identity;
using NoteIt.Application.Abstractions;
using NoteIt.Application.Handlers.Authentication;

namespace NoteIt.UnitTests.Mocks;
internal static class AuthenticationMock
{
    public static Mock<IJwtProvider> GetJwtProviderMock()
    {
        var jwtProvider = new Mock<IJwtProvider>();

        jwtProvider.Setup(x => x.GenerateJwt(It.IsAny<User>())).Returns(new JwtInfo { Token = "token" });

        return jwtProvider;
    }

    public static Mock<UserManager<User>> GetUserManagerMock()
    {
        var userPasswordStoreMock = new Mock<IUserPasswordStore<User>>();
        var userManagerMock = new Mock<UserManager<User>>(userPasswordStoreMock.Object, null, null, null, null, null, null, null, null);

        userManagerMock.Object.UserValidators.Add(new UserValidator<User>());
        userManagerMock.Object.PasswordValidators.Add(new PasswordValidator<User>());

        var identityResult = new IdentityResultMock(true);
        userManagerMock.Setup(x => x.CreateAsync(It.IsAny<User>())).ReturnsAsync(identityResult);
        userManagerMock.Setup(x => x.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(true);

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
