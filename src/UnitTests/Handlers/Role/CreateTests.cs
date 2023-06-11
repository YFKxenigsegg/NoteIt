using NoteIt.Application.Handlers.Role;

namespace NoteIt.UnitTests.Handlers.Role;
public class CreateTests
{
    private readonly Mock<IRoleRepository> _roleRepositoryMock;
    private readonly IMapper _mapper;

    public CreateTests()
    {
        _roleRepositoryMock = RoleRepositoryMock.GetRoleRepositoryMock();
        _mapper = new MapperConfiguration(config => config.AddProfile<MappingProfile>()).CreateMapper();
    }

    [Fact]
    public async Task Create_Role()
    {
        // Arrange
        var request = new CreateRequest() { Name = "Name-4" };
        var handler = new CreateHandler(_roleRepositoryMock.Object, _mapper);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        _roleRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        Assert.Equal(4, _roleRepositoryMock.Object.GetAll().Count());
    }

    [Fact]
    public async Task Throw_AlreadyExistException_For_Existing_Role()
    {
        // Arrange
        var request = new CreateRequest() { Name = "Name-1" };
        var handler = new CreateHandler(_roleRepositoryMock.Object, _mapper);

        // Assert
        var exception = await Assert.ThrowsAsync<AlreadyExistException>(async () =>
        {
            // Act
            await handler.Handle(request, CancellationToken.None);
        });
        Assert.Equal($"Entity \'Role\' ({request.Name}) already exist.", exception.Message);
    }
}
