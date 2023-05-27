using AutoMapper;
using Moq;
using Note.Application.Mappings;

namespace Note.UnitTests.Infrastructure.Helpers.Common;
public static class MapperHelper
{
    public static IMapper GetInstance()
        => new MapperConfiguration(config => config.AddProfile<MappingProfile>()).CreateMapper();

    public static Mock<IMapper> GetMock() => new Mock<IMapper>();
}
