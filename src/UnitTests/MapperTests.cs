using NoteIt.Application.Handlers.Note;
using NoteIt.Application.Handlers.Role;
using NoteIt.Application.Handlers.User;
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
    [InlineData(typeof(Application.Handlers.Note.CreateRequest), typeof(Note))]
    [InlineData(typeof(Note), typeof(Application.Handlers.Note.CreateRequest))]
    [InlineData(typeof(Application.Handlers.Note.UpdateRequest), typeof(Note))]
    [InlineData(typeof(Note), typeof(Application.Handlers.Note.UpdateRequest))]

    // Role
    [InlineData(typeof(ApplicationRole), typeof(RoleInfo))]
    [InlineData(typeof(RoleInfo), typeof(ApplicationRole))]
    [InlineData(typeof(Application.Handlers.Role.CreateRequest), typeof(ApplicationRole))]
    [InlineData(typeof(ApplicationRole), typeof(Application.Handlers.Role.CreateRequest))]

    // User
    [InlineData(typeof(ApplicationUser), typeof(UserInfo))]
    [InlineData(typeof(UserInfo), typeof(ApplicationUser))]
    [InlineData(typeof(Application.Handlers.User.CreateRequest), typeof(ApplicationUser))]
    //[InlineData(typeof(ApplicationUser), typeof(Application.Handlers.User.CreateRequest))]
    //[InlineData(typeof(Application.Handlers.User.UpdateRequest), typeof(ApplicationUser))]
    //[InlineData(typeof(ApplicationUser), typeof(Application.Handlers.User.UpdateRequest))]
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
