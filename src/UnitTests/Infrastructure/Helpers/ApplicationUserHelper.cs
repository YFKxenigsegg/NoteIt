//using Note.Domain.Entities;

//namespace Note.UnitTests.Infrastructure.Helpers;
//public static class ApplicationUserHelper
//{
//    public static ApplicationUser GetOne(string id = "a482b697-cd0d-479b-95e2-16e3cd36a561")
//    {
//        var role = ApplicationRoleHelper.GetOne();

//        var user = new ApplicationUser()
//        {
//            Id = id,
//            Email = "Test@gmail.com",
//            PasswordHash = "TestPasswordHash",
//            Created = DateTime.UtcNow,
//            RoleId = role.Id,
//            Role = role
//        };
//        role.Users = new List<ApplicationUser> { user };

//        return user;
//    }

//    public static IEnumerable<ApplicationUser> GetMany()
//    {
//        yield return GetOne();
//    }
//}
