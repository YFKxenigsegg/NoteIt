using AutoMapper;
using Note.Domain.Entities;
using Note.Infrastructure.Identity;

namespace Note.Application.Users.Create;
public partial class CreateRequest
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateRequest, ApplicationUser>()
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.UtcNow))
            .AfterMap<SetPasswordHashAction>();
    }
}

public class SetPasswordHashAction : IMappingAction<CreateRequest, ApplicationUser>
{
    public void Process(CreateRequest src, ApplicationUser dest, ResolutionContext _)
    {
        dest.PasswordHash = new SaltedPasswordHasher().HashPassword(dest, src.Password);
    }
}

