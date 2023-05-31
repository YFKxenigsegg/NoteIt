namespace NoteIt.UnitTests.Mocks;
internal class RoleRepositoryMock
{
    public static Mock<IRoleRepository> GetRoleRepositoryMock()
    {
        var roles = new List<ApplicationRole>()
        {
            new()
            {
                 Id = "00000000-0000-0000-0000-000000000001",
                 Name = "Name-1",
                 Created = DateTime.UtcNow
            },
            new()
            {
                 Id = "00000000-0000-0000-0000-000000000002",
                 Name = "Name-2",
                 Created = DateTime.UtcNow
            },
            new()
            {
                Id = "00000000-0000-0000-0000-000000000003",
                Name = "Name-3",
                Created = DateTime.UtcNow
            }
        };

        var repoMock = new Mock<IRoleRepository>();
        var uow = new Mock<IUnitOfWork>();

        repoMock.Setup(x => x.UnitOfWork).Returns(uow.Object);
        repoMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        repoMock.Setup(x => x.GetAll()).Returns(roles.AsEnumerable());
        repoMock.Setup(x => x.Add(It.IsAny<ApplicationRole>()))
            .Returns((ApplicationRole role) =>
            {
                role.Id = "00000000-0000-0000-0000-000000000004";
                roles.Add(role);
                return role;
            });
        repoMock.Setup(x => x.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((string id, CancellationToken token) =>
            {
                var role = roles.FirstOrDefault(x => x.Id == id);
                return role;
            });
        repoMock.Setup(x => x.GetByNameAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((string name, CancellationToken token) =>
            {
                var role = roles.FirstOrDefault(x => x.Name == name);
                return role;
            });

        return repoMock;
    }
}
