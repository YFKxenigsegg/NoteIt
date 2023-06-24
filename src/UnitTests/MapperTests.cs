using NoteIt.Application.Handlers.Notes;
using NoteIt.Application.Handlers.Users;
using System.Runtime.Serialization;

namespace NoteIt.UnitTests;
public class MapperTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MapperTests()
    {
        _configuration = new MapperConfiguration(config =>
            config.AddProfile<MappingProfile>());

        _mapper = _configuration.CreateMapper();
    }

    [Theory]
    // Note
    [InlineData(typeof(Note), typeof(NoteInfo))]
    [InlineData(typeof(NoteInfo), typeof(Note))]

    // User
    [InlineData(typeof(User), typeof(UserInfo))]
    [InlineData(typeof(UserInfo), typeof(User))]
    public void ShouldSupportMapingFromSrcToDest(Type src, Type dest)
    {
        var instance = GetInstanceOf(src);
        _mapper.Map(instance, src, dest);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        return FormatterServices.GetUninitializedObject(type);
    }
}
