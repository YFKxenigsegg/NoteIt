using Note.Application.Handlers.Note;
using Note.Application.Mappings;
using Note.Infrastructure.Exceptions;
using Note.Infrastructure.Persistence.Repositories.Interfaces;
using Note.UnitTests.Mocks;

namespace Note.UnitTests.Handlers.Note;
public class UpdateTests
{
    private readonly Mock<INoteRepository> _noteRepositoryMock;
    private readonly IMapper _mapper;

    public UpdateTests()
    {
        _noteRepositoryMock = NoteRepositoryMock.GetNoteRepositoryMock();
        _mapper = new MapperConfiguration(config => config.AddProfile<MappingProfile>()).CreateMapper();
    }

    [Fact]
    public async Task ShouldUpdateNote()
    {
        // Arrange
        var expectedName = "UpdatedName-1";
        var request = new UpdateRequest { Id = "00000000-0000-0000-0000-000000000001", Name = expectedName, Url = "Url-1" };
        var handler = new UpdateHandler(_noteRepositoryMock.Object, _mapper);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);
        var actualName = (await _noteRepositoryMock.Object.GetAsync(request.Id, CancellationToken.None))!.Name;

        // Assert
        _noteRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        Assert.Equal(expectedName, actualName);
    }

    [Fact]
    public async Task ShouldThrowNotFoundExceptionForUpdatedNote()
    {
        // Arrange
        var request = new UpdateRequest { Id = "00000000-0000-0000-0000-000000000000", Name = "UpdatedName-1", Url = "Url-1" };
        var handler = new UpdateHandler(_noteRepositoryMock.Object, _mapper);

        // Assert
        var exception = await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            // Act
            await handler.Handle(request, CancellationToken.None);
        });
        Assert.Equal($"Entity \'{nameof(Domain.Entities.Note)}\' ({request.Id}) was not found", exception.Message);
    }
}
