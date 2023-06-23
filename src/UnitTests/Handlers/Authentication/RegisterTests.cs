using Microsoft.AspNetCore.Identity;
using NoteIt.Application.Handlers.Authentication.Register;
using NoteIt.Domain.Consts;

namespace NoteIt.UnitTests.Handlers.Authentication;
public class RegisterTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IRoleRepository> _roleRepositoryMock;
    private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;

    public RegisterTests()
    {
        _userRepositoryMock = UserRepositoryMock.GetUserRepositoryMock();
        _roleRepositoryMock = RoleRepositoryMock.GetRoleRepositoryMock();
        _userManagerMock = AuthenticationMock.GetUserManagerMock();
    }

    [Fact]
    public async Task Register_Successful()
    {
        // Arrange
        _roleRepositoryMock.Setup(x => x.GetByNameAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ApplicationRole { Id = "Id" });

        var request = new RegisterRequest() { UserName = "UserName-1", Email = "Email-4", Password = "Val1dP@ss!", ConfirmPassword = "Val1dP@ss!" };
        var handler = new RegisterHandler(_userRepositoryMock.Object, _roleRepositoryMock.Object, _userManagerMock.Object);

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
        var handler = new RegisterHandler(_userRepositoryMock.Object, _roleRepositoryMock.Object, _userManagerMock.Object);

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
        _roleRepositoryMock.Setup(x => x.GetByNameAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ApplicationRole { Id = "Id" });
        var request = new RegisterRequest() { UserName = "UserName-4", Email = "Email-4", Password = "Val1dP@ss!", ConfirmPassword = "Val1dP@ss!" };
        var handler = new RegisterHandler(_userRepositoryMock.Object, _roleRepositoryMock.Object, _userManagerMock.Object);

        // Assert
        var exception = await Assert.ThrowsAsync<BadRequestException>(async () =>
        {
            // Act
            await handler.Handle(request, CancellationToken.None);
        });
        Assert.Equal("Something wrong", exception.Message);
    }
}
