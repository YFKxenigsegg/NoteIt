using NoteIt.Application.Handlers.Roles;

namespace NoteIt.WebApi.Controllers;
[Authorize]
public class RoleController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}
