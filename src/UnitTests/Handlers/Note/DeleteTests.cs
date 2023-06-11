using NoteIt.Application.Handlers.Note;

namespace NoteIt.UnitTests.Handlers.Note;
public class DeleteTests
{
    private readonly Mock<INoteRepository> _noteRepositoryMock;

    public DeleteTests()
    {
        _noteRepositoryMock = NoteRepositoryMock.GetNoteRepositoryMock();
    }

    [Fact]
    public async Task Delete_Note()
    {
        var request = new DeleteRequest { Id = "00000000-0000-0000-0000-000000000001" };
        var handler = new DeleteHandler(_noteRepositoryMock.Object);

        // Act
        await handler.Handle(request, CancellationToken.None);

        // Assert
        _noteRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
    }

    [Fact]
    public async Task Throw_NotFoundException_For_Not_Existing_Note()
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
