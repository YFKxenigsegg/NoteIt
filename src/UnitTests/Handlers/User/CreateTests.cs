using Note.Application.Handlers.User;
using Note.Application.Mappings;
using Note.Infrastructure.Exceptions;
using Note.UnitTests.Mocks;

namespace Note.UnitTests.Handlers.User;
public class CreateTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IRoleRepository> _roleRepositoryMock;
    private readonly IMapper _mapper;

    public CreateTests()
    {
        _userRepositoryMock = UserRepositoryMock.GetUserRepositoryMock();
        _roleRepositoryMock = RoleRepositoryMock.GetRoleRepositoryMock();
        _mapper = new MapperConfiguration(config => config.AddProfile<MappingProfile>()).CreateMapper();
    }

    [Fact]
    public async Task Create_User()
    {
        // Arrange
        var request = new CreateRequest() { Email = "Email-4", Password = "Password-1", RoleName = "Name-1" };
        var handler = new CreateHandler(_userRepositoryMock.Object, _roleRepositoryMock.Object, _mapper);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        _userRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        Assert.Equal(4, _userRepositoryMock.Object.GetAll().Count());
    }

    [Fact]
    public async Task Throw_AlreadyExistException_For_Existing_User()
    {
        // Arrange
        var request = new CreateRequest() { Email = "Email-1", Password = "Password-1", RoleName = "Name-1" };
        var handler = new CreateHandler(_userRepositoryMock.Object, _roleRepositoryMock.Object, _mapper);

        // Assert
        var exception = await Assert.ThrowsAsync<AlreadyExistException>(async () =>
        {
            // Act
            await handler.Handle(request, CancellationToken.None);
        });
        Assert.Equal($"User with \'{request.Email}\' already exist", exception.Message);
    }

    [Fact]
    public async Task Throw_NotFoundException_For_Not_Existing_Role()
    {
        // Arrange
        var request = new CreateRequest() { Email = "Email-4", Password = "Password-1", RoleName = "Name-4" };
        var handler = new CreateHandler(_userRepositoryMock.Object, _roleRepositoryMock.Object, _mapper);

        // Assert
        var exception = await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            // Act
            await handler.Handle(request, CancellationToken.None);
        });
        Assert.Equal($"Entity \'Role\' ({request.RoleName}) was not found", exception.Message);
    }
}
