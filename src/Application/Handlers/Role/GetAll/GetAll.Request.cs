using MediatR;

namespace Note.Application.Handlers.Role;
public class GetAllRequest : IRequest<IEnumerable<RoleInfo>> { }
