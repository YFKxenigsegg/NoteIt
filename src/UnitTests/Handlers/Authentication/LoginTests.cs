using Microsoft.AspNetCore.Identity;
using NoteIt.Application.Abstractions;
using NoteIt.Application.Handlers.Authentication.Login;

namespace NoteIt.UnitTests.Handlers.Authentication;
public class LoginTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IJwtProvider> _jwtProviderMock;
    private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;

    public LoginTests()
    {
        _userRepositoryMock = UserRepositoryMock.GetUserRepositoryMock();
        _jwtProviderMock = AuthenticationMock.GetJwtProviderMock();
        _userManagerMock = AuthenticationMock.GetUserManagerMock();
    }

    [Fact]
    public async Task Login_Successful()
    {
        // Arrange
        var request = new LoginRequest() { Email = "Email-1", Password = "Val1dP@ss!" };
        var handler = new LoginHandler(_userRepositoryMock.Object, _jwtProviderMock.Object, _userManagerMock.Object);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Throw_NotFoundException_For_Not_Existing_User()
    {
        // Arrange
        var request = new LoginRequest() { Email = "Email-4", Password = "Val1dP@ss!" };
        var handler = new LoginHandler(_userRepositoryMock.Object, _jwtProviderMock.Object, _userManagerMock.Object);

        // Assert
        var exception = await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            // Act
            await handler.Handle(request, CancellationToken.None);
        });
        Assert.Equal($"Entity \'User\' ({request.Email}) was not found", exception.Message);
    }

    [Fact]
    public async Task Throw_BadRequestException_For_Invalid_Password()
    {
        // Arrange
        _userManagerMock.Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(false);
        var request = new LoginRequest() { Email = "Email-1", Password = "InVal1dP@ss!" };
        var handler = new LoginHandler(_userRepositoryMock.Object, _jwtProviderMock.Object, _userManagerMock.Object);

        // Assert
        var exception = await Assert.ThrowsAsync<BadRequestException>(async () =>
        {
            // Act
            await handler.Handle(request, CancellationToken.None);
        });
        Assert.Equal("Invalid password", exception.Message);
    }
}
