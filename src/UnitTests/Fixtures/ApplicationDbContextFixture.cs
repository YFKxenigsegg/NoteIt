using Note.Infrastructure.Persistence;
using Note.UnitTests.Infrastructure.Helpers;
using Note.UnitTests.Infrastructure.Helpers.Common;

namespace Note.UnitTests.Fixtures;
public class ApplicationDbContextFixture
{
    public ApplicationDbContext Create()
    { 
        var dbContext =  new ApplicationDbContextHelper().DbContext;

        dbContext.Users.AddRange(ApplicationUserHelper.GetMany());
        dbContext.SaveChanges();

        return dbContext;
    }
}
