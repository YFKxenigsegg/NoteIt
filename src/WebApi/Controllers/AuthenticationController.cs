using NoteIt.Application.Handlers.Authentication.Login;
using NoteIt.Application.Handlers.Authentication.Register;

namespace NoteIt.WebApi.Controllers;
public class AuthenticationController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}
