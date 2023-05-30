namespace Note.Application.Handlers.User;
public class GetRequest : IRequest<UserInfo>
{
    public string Id { get; set; } = default!;
}
