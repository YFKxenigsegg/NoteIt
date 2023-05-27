//using AutoMapper;
//using MediatR;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Note.Domain.Entities;
//using Note.Infrastructure.Exceptions;
//using Note.Infrastructure.Persistence.Repositories.Interfaces;

//namespace Note.Application.Handlers.User.Create;
//public class CreateHandler : IRequestHandler<CreateRequest, string>
//{
//    private readonly IMapper _mapper;
//    private readonly UserManager<ApplicationUser> _userManager;

//    public CreateHandler(
//        IMapper mapper
//        , UserManager<ApplicationUser> userManager
//        )
//    {
//        _mapper = mapper;
//        _userManager = userManager;
//    }

//    public async Task<string> Handle(CreateRequest request, CancellationToken cancellationToken)
//    {
//        if (await _userManager.FindByEmailAsync(request.Email) != null)
//            throw new AlreadyExistException($"User with \'{request.Email}\' already exist.");

//        var user = _mapper.Map<ApplicationUser>(request);

//        user.RoleId = (await _roles.GetIdByNameAsync(request.RoleName, cancellationToken))
//            ?? throw new NotFoundException("Role", request.RoleName);

//        return user.Id;
//    }
//}
