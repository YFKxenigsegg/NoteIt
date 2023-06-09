﻿using NoteIt.Application.Handlers.Users;

namespace NoteIt.UnitTests.Handlers.Users;
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
