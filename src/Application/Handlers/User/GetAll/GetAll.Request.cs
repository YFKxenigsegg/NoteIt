using MediatR;

namespace Note.Application.Handlers.User;
public class GetAllRequest : IRequest<IEnumerable<UserInfo>> { }
