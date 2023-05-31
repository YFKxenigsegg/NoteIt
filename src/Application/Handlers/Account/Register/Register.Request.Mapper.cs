﻿namespace NoteIt.Application.Handlers.Account;
public partial class RegisterRequest
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}