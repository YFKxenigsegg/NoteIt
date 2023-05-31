using NoteIt.Application.Handlers.Note;
using NoteIt.Application.Mappings;
using NoteIt.UnitTests.Mocks;

namespace NoteIt.UnitTests.Handlers.Note;
public class GetAllTests
{
    private readonly Mock<INoteRepository> _noteRepositoryMock;
    private readonly IMapper _mapper;

    public GetAllTests()
    {
        _noteRepositoryMock = NoteRepositoryMock.GetNoteRepositoryMock();
        _mapper = new MapperConfiguration(config => config.AddProfile<MappingProfile>()).CreateMapper();
    }

    [Fact]
    public async Task Get_Notes()
    {
        // Arrange
        var request = new GetAllRequest();
        var handler = new GetAllHandler(_noteRepositoryMock.Object, _mapper);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.IsAssignableFrom<IEnumerable<NoteInfo>>(result);
        Assert.Equal(3, result.Count());
    }
}
