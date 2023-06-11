namespace NoteIt.Application.Handlers.User;
public partial class CreateRequest
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateRequest, ApplicationUser>()
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}