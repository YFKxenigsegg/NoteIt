using Note.Application.Handlers.Role;
using Note.Application.Mappings;
using Note.Infrastructure.Exceptions;
using Note.Infrastructure.Persistence.Repositories.Interfaces;
using Note.UnitTests.Mocks;

namespace Note.UnitTests.Handlers.Role;
public class GetTests
{
    private readonly Mock<IRoleRepository> _roleRepositoryMock;
    private readonly IMapper _mapper;

    public GetTests()
    {
        _roleRepositoryMock = RoleRepositoryMock.GetRoleRepositoryMock();
        _mapper = new MapperConfiguration(config => config.AddProfile<MappingProfile>()).CreateMapper();
    }

    [Fact]
    public async Task ShouldReturnExistingNote()
    {
        // Arrange
        var request = new GetRequest { Id = "00000000-0000-0000-0000-000000000001" };
        var handler = new GetHandler(_roleRepositoryMock.Object, _mapper);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ShouldThrowNotFoundExceptionForNotExistingNote()
    {
        // Arrange
        var request = new GetRequest { Id = "00000000-0000-0000-0000-000000000000" };
        var handler = new GetHandler(_roleRepositoryMock.Object, _mapper);

        // Assert
        var exception = await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            // Act
            await handler.Handle(request, CancellationToken.None);
        });
        Assert.Equal($"Entity \'Role\' ({request.Id}) was not found", exception.Message);
    }
}
