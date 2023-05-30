using Note.Application.Handlers.User;
using Note.Application.Mappings;
using Note.Infrastructure.Persistence.Repositories.Interfaces;
using Note.UnitTests.Mocks;

namespace Note.UnitTests.Handlers.User;
public class GetAllTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly IMapper _mapper;

    public GetAllTests()
    {
        _userRepositoryMock = UserRepositoryMock.GetUserRepositoryMock();
        _mapper = new MapperConfiguration(config => config.AddProfile<MappingProfile>()).CreateMapper();
    }

    [Fact]
    public async Task Get_Users()
    {
        // Arrange
        var request = new GetAllRequest();
        var handler = new GetAllHandler(_userRepositoryMock.Object, _mapper);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.IsAssignableFrom<IEnumerable<UserInfo>>(result);
        Assert.Equal(3, result.Count());
    }
}
