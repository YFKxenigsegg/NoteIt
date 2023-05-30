using Note.Application.Handlers.Note;
using Note.Infrastructure.Exceptions;
using Note.Infrastructure.Persistence.Repositories.Interfaces;
using Note.UnitTests.Mocks;

namespace Note.UnitTests.Handlers.Note;
public class DeleteTests
{
    private readonly Mock<INoteRepository> _noteRepositoryMock;

    public DeleteTests()
    {
        _noteRepositoryMock = NoteRepositoryMock.GetNoteRepositoryMock();
    }

    [Fact]
    public async Task ShouldDeleteExistingNote()
    {
        var request = new DeleteRequest { Id = "00000000-0000-0000-0000-000000000001" };
        var handler = new DeleteHandler(_noteRepositoryMock.Object);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        _noteRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task ShouldThrowNotFoundExceptionForNotExistingNote()
    {
        // Arrange
        var request = new DeleteRequest { Id = "00000000-0000-0000-0000-000000000000" };
        var handler = new DeleteHandler(_noteRepositoryMock.Object);

        // Assert
        var exception = await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            // Act
            await handler.Handle(request, CancellationToken.None);
        });
        Assert.Equal($"Entity \'{nameof(Domain.Entities.Note)}\' ({request.Id}) was not found", exception.Message);
    }
}
