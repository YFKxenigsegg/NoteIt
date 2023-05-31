using NoteIt.Application.Handlers.Note;
using NoteIt.Application.Mappings;
using NoteIt.UnitTests.Mocks;

namespace NoteIt.UnitTests.Handlers.Note;
public class CreateTests
{
    private readonly Mock<INoteRepository> _noteRepositoryMock;
    private readonly IMapper _mapper;

    public CreateTests()
    {
        _noteRepositoryMock = NoteRepositoryMock.GetNoteRepositoryMock();
        _mapper = new MapperConfiguration(config => config.AddProfile<MappingProfile>()).CreateMapper();
    }

    [Fact]
    public async Task Create_Note()
    {
        // Arrange
        var request = new CreateRequest() { Name = "CreateName", Url = "CreateUrl" };
        var handler = new CreateHandler(_noteRepositoryMock.Object, _mapper);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        _noteRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        Assert.Equal(4, _noteRepositoryMock.Object.GetAll().Count());
    }
}
