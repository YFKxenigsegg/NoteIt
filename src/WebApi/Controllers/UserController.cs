using NoteIt.Application.Handlers.Users;

namespace NoteIt.WebApi.Controllers;
[Authorize]
public class UserController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}
