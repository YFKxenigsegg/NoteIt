using Note.Domain.Entities;

namespace Note.Application.Handlers.User.Register;
public partial class RegisterRequest
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
