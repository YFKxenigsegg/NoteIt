using NoteIt.Application.Handlers.Users;

namespace NoteIt.UnitTests.Handlers.Users;
public class UpdateTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly IMapper _mapper;

    public UpdateTests()
    {
        _userRepositoryMock = UserRepositoryMock.GetUserRepositoryMock();
        _mapper = new MapperConfiguration(config => config.AddProfile<MappingProfile>()).CreateMapper();
    }

    [Fact]
    public async Task Throw_NotFoundException_For_Not_Existing_User()
    {
        // Arrange
        var request = new UpdateRequest { Id = "00000000-0000-0000-0000-000000000004", RoleName = "Name-1" };
        var handler = new UpdateHandler(_userRepositoryMock.Object, _mapper);

        // Assert
        var exception = await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            // Act
            await handler.Handle(request, CancellationToken.None);
        });
        Assert.Equal($"Entity \'User\' ({request.Id}) was not found", exception.Message);
    }
}
