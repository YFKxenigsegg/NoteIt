using Note.Application.Handlers.Note;
using Note.Application.Mappings;
using Note.Infrastructure.Exceptions;
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
    public async Task Update_Note_Name()
    {
        // Arrange
        var expectedName = "UpdatedName-1";
        var request = new UpdateRequest { Id = "00000000-0000-0000-0000-000000000001", Name = expectedName, Url = "Url-1" };
        var handler = new UpdateHandler(_noteRepositoryMock.Object, _mapper);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);
        var actualName = result.Name;

        // Assert
        _noteRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        Assert.Equal(expectedName, actualName);
    }

    [Fact]
    public async Task Update_Note_Url()
    {
        // Arrange
        var expectedUrl = "UpdatedUrl-2";
        var request = new UpdateRequest { Id = "00000000-0000-0000-0000-000000000001", Name = "Name-1", Url = expectedUrl };
        var handler = new UpdateHandler(_noteRepositoryMock.Object, _mapper);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);
        var actualUrl = result.Url;

        // Assert
        _noteRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public async Task Throw_NotFoundException_For_Not_Existing_Note()
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
