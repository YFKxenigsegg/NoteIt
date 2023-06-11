using NoteIt.Application.Handlers.Role;

namespace NoteIt.UnitTests.Handlers.Role;
public class GetAllTests
{
    private readonly Mock<IRoleRepository> _roleRepositoryMock;
    private readonly IMapper _mapper;

    public GetAllTests()
    {
        _roleRepositoryMock = RoleRepositoryMock.GetRoleRepositoryMock();
        _mapper = new MapperConfiguration(config => config.AddProfile<MappingProfile>()).CreateMapper();
    }

    [Fact]
    public async Task Get_Roles()
    {
        // Arrange
        var request = new GetAllRequest();
        var handler = new GetAllHandler(_roleRepositoryMock.Object, _mapper);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.IsAssignableFrom<IEnumerable<RoleInfo>>(result);
        Assert.Equal(3, result.Count());
    }
}
