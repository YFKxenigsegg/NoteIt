using Note.Application.Handlers.Note;
using Note.Application.Mappings;
using System.Runtime.Serialization;

namespace Note.UnitTests.Handlers.Note;
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
    [InlineData(typeof(Domain.Entities.Note), typeof(NoteInfo))]
    [InlineData(typeof(NoteInfo), typeof(Domain.Entities.Note))]
    [InlineData(typeof(CreateRequest), typeof(Domain.Entities.Note))]
    [InlineData(typeof(Domain.Entities.Note), typeof(CreateRequest))]
    [InlineData(typeof(UpdateRequest), typeof(Domain.Entities.Note))]
    [InlineData(typeof(Domain.Entities.Note), typeof(UpdateRequest))]
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
