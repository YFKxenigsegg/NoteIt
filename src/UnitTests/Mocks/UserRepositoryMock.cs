﻿namespace NoteIt.UnitTests.Mocks;
internal static class UserRepositoryMock
{
    public static Mock<IUserRepository> GetUserRepositoryMock()
    {
        var users = new List<ApplicationUser>()
        {
            new()
            {
                 Id = "00000000-0000-0000-0000-000000000001",
                 Email = "Email-1",
                 PasswordHash = "PasswordHash-1",
                 Created = DateTime.UtcNow,
                 RoleId = "00000000-0000-0000-0000-000000000001"
            },
            new()
            {
                 Id = "00000000-0000-0000-0000-000000000002",
                 Email = "Email-2",
                 PasswordHash = "PasswordHash-2",
                 Created = DateTime.UtcNow,
                 RoleId = "00000000-0000-0000-0000-000000000002"
            },
            new()
            {
                Id = "00000000-0000-0000-0000-000000000003",
                Email = "Email-3",
                PasswordHash = "PasswordHash-3",
                Created = DateTime.UtcNow,
                RoleId = "00000000-0000-0000-0000-000000000001"
            }
        };

        var repoMock = new Mock<IUserRepository>();
        var uow = new Mock<IUnitOfWork>();

        repoMock.Setup(x => x.UnitOfWork).Returns(uow.Object);
        repoMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        repoMock.Setup(x => x.GetAll()).Returns(users.AsEnumerable());
        repoMock.Setup(x => x.Add(It.IsAny<ApplicationUser>()))
            .Returns((ApplicationUser user) =>
            {
                user.Id = "00000000-0000-0000-0000-000000000004";
                user.RoleId = "00000000-0000-0000-0000-000000000004";
                users.Add(user);
                return user;
            });
        repoMock.Setup(x => x.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((string id, CancellationToken token) =>
            {
                var role = users.Find(x => x.Id == id);
                return role;
            });
        repoMock.Setup(x => x.GetByEmailAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((string email, CancellationToken token) =>
            {
                var user = users.Find(x => x.Email == email);
                return user;
            });

        return repoMock;
    }
}
