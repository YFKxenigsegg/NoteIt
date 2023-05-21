using AutoMapper;
using Note.Domain.Entities;
using Note.Infrastructure.Identity;

namespace Note.Application.Handlers.User.Register;
public partial class RegisterRequest
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.UtcNow))
            .AfterMap<SetPasswordHashAction>();
    }
}

public class SetPasswordHashAction : IMappingAction<RegisterRequest, ApplicationUser>
{
    public void Process(RegisterRequest src, ApplicationUser dest, ResolutionContext _)
    {
        dest.PasswordHash = new SaltedPasswordHasher().HashPassword(dest, src.Password);
    }
}
