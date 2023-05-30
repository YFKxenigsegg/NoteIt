using Note.Application.Handlers.Role;
using Note.Application.Mappings;
using Note.Infrastructure.Persistence.Repositories.Interfaces;
using Note.UnitTests.Mocks;

namespace Note.UnitTests.Handlers.Role;
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
    public async Task ShouldReturnAllThreeRoles()
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
