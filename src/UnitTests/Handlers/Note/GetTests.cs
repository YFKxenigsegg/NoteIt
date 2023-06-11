using NoteIt.Application.Handlers.Note;

namespace NoteIt.UnitTests.Handlers.Note;
public class GetTests
{
    private readonly Mock<INoteRepository> _noteRepositoryMock;
    private readonly IMapper _mapper;

    public GetTests()
    {
        _noteRepositoryMock = NoteRepositoryMock.GetNoteRepositoryMock();
        _mapper = new MapperConfiguration(config => config.AddProfile<MappingProfile>()).CreateMapper();
    }

    [Fact]
    public async Task Get_Note()
    {
        // Arrange
        var request = new GetRequest { Id = "00000000-0000-0000-0000-000000000001" };
        var handler = new GetHandler(_noteRepositoryMock.Object, _mapper);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Throw_NotFoundException_For_Not_Existing_Note()
    {
        // Arrange
        var request = new GetRequest { Id = "00000000-0000-0000-0000-000000000000" };
        var handler = new GetHandler(_noteRepositoryMock.Object, _mapper);

        // Assert
        var exception = await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            // Act
            await handler.Handle(request, CancellationToken.None);
        });
        Assert.Equal($"Entity \'{nameof(Domain.Entities.Note)}\' ({request.Id}) was not found", exception.Message);
    }
}
