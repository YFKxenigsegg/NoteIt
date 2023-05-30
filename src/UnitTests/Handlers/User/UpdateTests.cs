using Note.Application.Handlers.User;
using Note.Application.Mappings;
using Note.Infrastructure.Exceptions;
using Note.Infrastructure.Persistence.Repositories.Interfaces;
using Note.UnitTests.Mocks;

namespace Note.UnitTests.Handlers.User;
public class UpdateTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IRoleRepository> _roleRepositoryMock;
    private readonly IMapper _mapper;

    public UpdateTests()
    {
        _userRepositoryMock = UserRepositoryMock.GetUserRepositoryMock();
        _roleRepositoryMock = RoleRepositoryMock.GetRoleRepositoryMock();
        _mapper = new MapperConfiguration(config => config.AddProfile<MappingProfile>()).CreateMapper();
    }

    [Fact]
    public async Task Update_User_RoleId()
    {
        // Arrange
        var expectedRoleId = "00000000-0000-0000-0000-000000000002";
        var roleName = "Name-2";
        var request = new UpdateRequest { Id = "00000000-0000-0000-0000-000000000001", RoleName = roleName };
        var handler = new UpdateHandler(_userRepositoryMock.Object, _roleRepositoryMock.Object, _mapper);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);
        var actualRoleId = result.RoleId;

        // Assert
        _userRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        Assert.Equal(expectedRoleId, actualRoleId);
    }

    [Fact]
    public async Task Throw_NotFoundException_For_Not_Existing_Role()
    {
        // Arrange
        var request = new UpdateRequest { Id = "00000000-0000-0000-0000-000000000001", RoleName = "Name-4" };
        var handler = new UpdateHandler(_userRepositoryMock.Object, _roleRepositoryMock.Object, _mapper);

        // Assert
        var exception = await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            // Act
            await handler.Handle(request, CancellationToken.None);
        });
        Assert.Equal($"Entity \'Role\' ({request.RoleName}) was not found", exception.Message);
    }

    [Fact]
    public async Task Throw_NotFoundException_For_Not_Existing_User()
    {
        // Arrange
        var request = new UpdateRequest { Id = "00000000-0000-0000-0000-000000000004", RoleName = "Name-1" };
        var handler = new UpdateHandler(_userRepositoryMock.Object, _roleRepositoryMock.Object, _mapper);

        // Assert
        var exception = await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            // Act
            await handler.Handle(request, CancellationToken.None);
        });
        Assert.Equal($"Entity \'User\' ({request.Id}) was not found", exception.Message);
    }
}
