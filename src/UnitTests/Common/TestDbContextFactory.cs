//using Microsoft.EntityFrameworkCore;
//using Note.Infrastructure.Persistence;

//namespace Note.UnitTests.Common;
//public class TestDbContextFactory : IDbContextFactory<ApplicationDbContext>
//{
//    private readonly DbContextOptions<ApplicationDbContext> _options;

//    public TestDbContextFactory(string databaseName = "InMemoryTest")
//    {
//        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
//            .UseInMemoryDatabase(databaseName).Options;
//    }

//    public ApplicationDbContext CreateDbContext() => new(_options);
//}
