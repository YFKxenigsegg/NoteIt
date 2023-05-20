using AutoMapper;
using Note.Domain.Entities;
using Note.Infrastructure.Identity;

namespace Note.Application.Users.Users.Register;
public partial class RegisterRequest
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.UtcNow)) //interceptor not working
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
