using NoteIt.Application.Handlers.User;

namespace NoteIt.Application.Handlers.Account;
public partial class RegisterRequest : IMapFrom<CreateRequest>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<RegisterRequest, CreateRequest>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => Domain.Consts.Roles.User));
    }
}
