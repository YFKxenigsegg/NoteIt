using Note.Domain.Entities;
using Note.UnitTests.Fixtures;
using Note.UnitTests.Infrastructure.Helpers;
using Xunit;

namespace Note.UnitTests;
public class ApplicationDbContextTests : IClassFixture<ApplicationDbContextFixture>
{
    private readonly ApplicationDbContextFixture _dbContextFixture;

    public ApplicationDbContextTests(ApplicationDbContextFixture dbContextFixture)
        => _dbContextFixture = dbContextFixture;

    [Fact]
    public void ItShould_create_instance()
    {
        // arrange
        var sut = _dbContextFixture.Create();

        // act

        // assert
        Assert.NotNull(sut);
    }

    [Fact]
    public void ItShould_contains_one_user()
    {
        // arrange
        const int expected = 1;
        var sut = _dbContextFixture.Create();

        // act
        var actual = sut.Users.Count();

        // assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ItShould_user_with_special_id()
    {
        // arrange
        var userId = ApplicationUserHelper.GetOne().Id;
        var sut = _dbContextFixture.Create();

        // act
        var actual = sut.Users.FirstOrDefault(x => x.Id == userId);

        // assert
        Assert.NotNull(actual);
        Assert.Single(sut.Users.AsEnumerable(), x => x.Id == userId);
    }

    [Fact]
    public void ItShould_user_with_special_unique_email()
    {
        // arrange
        const string email = "Test@gmail.com";
        var sut = _dbContextFixture.Create();

        // act
        var user = sut.Users.FirstOrDefault(x => x.Email == email);

        // assert
        Assert.NotNull(user);
        Assert.Single(sut.Users.AsEnumerable(), x => x.Email == email);
    }

    [Fact]
    public void ItShould_user_with_special_passwordHash()
    {
        // arrange
        const string passwordHash = "TestPasswordHash";
        var sut = _dbContextFixture.Create();

        // act
        var user = sut.Users.FirstOrDefault(x => x.PasswordHash == passwordHash);

        // assert
        Assert.NotNull(user);
    }

    [Fact]
    public void ItShould_user_have_not_default_created()
    {
        // arrange
        var userId = ApplicationUserHelper.GetOne().Id;
        var sut = _dbContextFixture.Create();

        // act
        var actual = sut.Users.FirstOrDefault(x => x.Id == userId)?.Created;

        // assert
        Assert.NotEqual(DateTime.MinValue, actual);
    }

    [Fact]
    public void ItShould_user_with_role()
    {
        // arrange
        var userId = ApplicationUserHelper.GetOne().Id;
        var sut = _dbContextFixture.Create();

        // act
        var user = sut.Users.FirstOrDefault(x => x.Id == userId);

        // assert
        Assert.NotNull(user?.Role);
        Assert.NotNull(user?.RoleId);
    }

    [Fact]
    public void ItShould_contains_one_role()
    {
        // arrange
        const int expected = 1;
        var sut = _dbContextFixture.Create();

        // act
        var actual = sut.Roles.Count();

        // assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ItShould_role_with_special_id()
    {
        // arrange
        var roleId = ApplicationRoleHelper.GetOne().Id;
        var sut = _dbContextFixture.Create();

        // act
        var actual = sut.Roles.FirstOrDefault(x => x.Id == roleId);

        // assert
        Assert.NotNull(actual);
        Assert.Single(sut.Roles.AsEnumerable(), x => x.Id == roleId);
    }

    [Fact]
    public void ItShould_role_with_special_unique_name()
    {
        // arrange
        const string name = "TestRoleName";
        var sut = _dbContextFixture.Create();

        // act
        var role = sut.Roles.FirstOrDefault(x => x.Name == name);

        // assert
        Assert.NotNull(role);
        Assert.Single(sut.Roles.AsEnumerable(), x => x.Name == name);
    }

    [Fact]
    public void ItShould_role_with_users()
    {
        // arrange
        var roleId = ApplicationRoleHelper.GetOne().Id;
        var sut = _dbContextFixture.Create();

        // act
        var users = sut.Roles.FirstOrDefault(x => x.Id == roleId)?.Users;

        // assert
        Assert.NotNull(users);
        Assert.NotEmpty(users);
    }
}
