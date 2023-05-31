//using NoteIt.Infrastructure.Persistence;
//using NoteIt.UnitTests.Infrastructure.Helpers;
//using NoteIt.UnitTests.Infrastructure.Helpers.Common;

//namespace NoteIt.UnitTests.Fixtures;
//public class ApplicationDbContextFixture
//{
//    public ApplicationDbContext Create()
//    { 
//        var dbContext =  new ApplicationDbContextHelper().DbContext;

//        dbContext.Users.AddRange(ApplicationUserHelper.GetMany());
//        dbContext.SaveChanges();

//        return dbContext;
//    }
//}
