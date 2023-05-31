using AutoMapper;
using Moq;
using NoteIt.Application.Mappings;

namespace NoteIt.UnitTests.Infrastructure.Helpers.Common;
public static class MapperHelper
{
    public static IMapper GetInstance()
        => new MapperConfiguration(config => config.AddProfile<MappingProfile>()).CreateMapper();

    public static Mock<IMapper> GetMock() => new Mock<IMapper>();
}
