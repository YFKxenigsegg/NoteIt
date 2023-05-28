using Note.Application.Handlers.Note;
using Note.Application.Mappings;
using Note.Infrastructure.Persistence.Repositories.Interfaces;
using Note.UnitTests.Mocks;

namespace Note.UnitTests.Handlers.Note;
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
    public async Task ShouldReturnAllThreeNotes()
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
