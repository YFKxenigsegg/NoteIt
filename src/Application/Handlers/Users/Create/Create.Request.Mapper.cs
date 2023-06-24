namespace NoteIt.Application.Handlers.Users;
public partial class CreateRequest
{
    public void Mapping(Profile profile)
    {
        //profile.CreateMap<CreateRequest, User>()
        //    .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}