namespace NoteIt.UnitTests.Mocks;
internal static class NoteRepositoryMock
{
    public static Mock<INoteRepository> GetNoteRepositoryMock()
    {
        var notes = new List<Note>()
        {
            new()
            {
                 Id = "00000000-0000-0000-0000-000000000001",
                 Name = "Name-1",
                 Url ="Url-1",
                 Created = DateTime.UtcNow
            },
            new()
            {
                 Id = "00000000-0000-0000-0000-000000000002",
                 Name = "Name-2",
                 Url ="Url-2",
                 Created = DateTime.UtcNow
            },
            new()
            {
                Id = "00000000-0000-0000-0000-000000000003",
                Name = "Name-3",
                Url ="Url-3",
                Created = DateTime.UtcNow
            }
        };

        var repoMock = new Mock<INoteRepository>();
        var uow = new Mock<IUnitOfWork>();

        repoMock.Setup(x => x.UnitOfWork).Returns(uow.Object);
        repoMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        repoMock.Setup(x => x.GetAll()).Returns(notes.AsEnumerable());
        repoMock.Setup(x => x.Add(It.IsAny<Domain.Entities.Note>()))
            .Returns((Domain.Entities.Note note) =>
            {
                note.Id = "00000000-0000-0000-0000-000000000004";
                notes.Add(note);
                return note;
            });
        repoMock.Setup(x => x.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((string id, CancellationToken token) =>
            {
                var note = notes.Find(x => x.Id == id);
                return note;
            });

        return repoMock;
    }
}
