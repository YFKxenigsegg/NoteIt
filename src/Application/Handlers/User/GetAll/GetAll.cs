﻿using AutoMapper;
using MediatR;
using Note.Infrastructure.Persistence.Repositories.Interfaces;

namespace Note.Application.Handlers.User;
public class GetAllHandler : IRequestHandler<GetAllRequest, IEnumerable<UserInfo>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllHandler(
        IUserRepository userRepository
        , IMapper mapper
        )
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserInfo>> Handle(GetAllRequest request, CancellationToken cancellationToken)
    {
        var users = _userRepository.GetAll();
        var result = _mapper.Map<IEnumerable<UserInfo>>(users);

        return result;
    }
}
