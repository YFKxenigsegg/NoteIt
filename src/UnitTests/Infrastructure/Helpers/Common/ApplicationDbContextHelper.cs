//using Microsoft.EntityFrameworkCore;
//using Moq;
//using Note.Infrastructure.Persistence;
//using Note.Infrastructure.Persistence.Helpers.Interfaces;

//namespace Note.UnitTests.Infrastructure.Helpers.Common;
//public class ApplicationDbContextHelper
//{
//    public ApplicationDbContext DbContext { get; set; }

//    public ApplicationDbContextHelper()
//    {
//        var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
//            .UseInMemoryDatabase(Guid.NewGuid().ToString());

//        var dateTimeHelperMock = new Mock<IDateTimeHelper>();
//        dateTimeHelperMock.Setup(x => x.UtcNow).Returns(DateTime.UtcNow);

//        //DbContext = new ApplicationDbContext(builder.Options, new AuditableEntitySaveChangesInterceptor(dateTimeHelperMock.Object));
//    }
//}
