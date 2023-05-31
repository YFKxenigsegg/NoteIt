using NoteIt.Domain.Entities;

namespace NoteIt.UnitTests.Infrastructure.Helpers;
public static class ApplicationRoleHelper
{
    public static ApplicationRole GetOne(string id = "84c5c796-1d5f-4222-a68d-5b0cb0ea4de8")
    {
        return new ApplicationRole { Id = id, Name = "TestRoleName" };
    }

    public static IEnumerable<ApplicationRole> GetMany()
    {
        yield return GetOne();
    }
}
