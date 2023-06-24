using Microsoft.AspNetCore.Identity;
using NoteIt.Application.Handlers.Authentication;

namespace NoteIt.UnitTests.Handlers.Authentication;
public class RegisterTests
{
    private readonly Mock<UserManager<User>> _userManagerMock;

    public RegisterTests()
    {
        _userManagerMock = AuthenticationMock.GetUserManagerMock();
    }

    [Fact]
    public async Task Register_Successful()
    {
        // Arrange
        var request = new RegisterRequest() { UserName = "UserName-1", Email = "Email-4", Password = "Val1dP@ss!", ConfirmPassword = "Val1dP@ss!" };
        var handler = new RegisterHandler(_userManagerMock.Object);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        //Assert.NotNull(result);
    }

    [Fact]
    public async Task Throw_AlreadyExistException_For_Existing_User()
    {
        // Arrange
        var request = new RegisterRequest() { UserName = "UserName-1", Email = "Email-1", Password = "Val1dP@ss!", ConfirmPassword = "Val1dP@ss!" };
        var handler = new RegisterHandler(_userManagerMock.Object);

        // Assert
        var exception = await Assert.ThrowsAsync<AlreadyExistException>(async () =>
        {
            // Act
            await handler.Handle(request, CancellationToken.None);
        });
        Assert.Equal($"Entity \'User\' ({request.Email}) already exist.", exception.Message);
    }

    [Fact]
    public async Task Throw_BadRequestException_For_Invalid_Registration()
    {
        // Arrange
        var request = new RegisterRequest() { UserName = "UserName-4", Email = "Email-4", Password = "Val1dP@ss!", ConfirmPassword = "Val1dP@ss!" };
        var handler = new RegisterHandler(_userManagerMock.Object);

        // Assert
        var exception = await Assert.ThrowsAsync<BadRequestException>(async () =>
        {
            // Act
            await handler.Handle(request, CancellationToken.None);
        });
        Assert.Equal("Something wrong", exception.Message);
    }
}
