using Note.Application.Handlers.Note;
using Note.Application.Mappings;
using Note.Infrastructure.Exceptions;
using Note.Infrastructure.Persistence.Repositories.Interfaces;
using Note.UnitTests.Mocks;

namespace Note.UnitTests.Handlers.Note;
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
    public async Task ShouldReturnExistingNote()
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
    public async Task ShouldThrowNotFoundExceptionForNotExistingNote()
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
        Assert.Equal($"Entity \"{nameof(Domain.Entities.Note)}\" ({request.Id}) was not found", exception.Message);
    }
}
