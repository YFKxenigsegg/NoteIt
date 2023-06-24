using NoteIt.Application.Handlers.Roles;

namespace NoteIt.WebApi.Controllers;
public class RoleController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(GetAllRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}
