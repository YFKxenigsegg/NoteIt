using Note.Application.Handlers.User;
using Note.Application.Mappings;
using Note.Infrastructure.Exceptions;
using Note.Infrastructure.Persistence.Repositories.Interfaces;
using Note.UnitTests.Mocks;

namespace Note.UnitTests.Handlers.User;
public class GetTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly IMapper _mapper;

    public GetTests()
    {
        _userRepositoryMock = UserRepositoryMock.GetUserRepositoryMock();
        _mapper = new MapperConfiguration(config => config.AddProfile<MappingProfile>()).CreateMapper();
    }

    [Fact]
    public async Task Get_User()
    {
        // Arrange
        var request = new GetRequest { Id = "00000000-0000-0000-0000-000000000001" };
        var handler = new GetHandler(_userRepositoryMock.Object, _mapper);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Throw_NotFoundException_For_Not_Existing_User()
    {
        // Arrange
        var request = new GetRequest { Id = "00000000-0000-0000-0000-000000000000" };
        var handler = new GetHandler(_userRepositoryMock.Object, _mapper);

        // Assert
        var exception = await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            // Act
            await handler.Handle(request, CancellationToken.None);
        });
        Assert.Equal($"Entity \'User\' ({request.Id}) was not found", exception.Message);
    }
}
