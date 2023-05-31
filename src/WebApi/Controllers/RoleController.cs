using Microsoft.AspNetCore.Mvc;
using NoteIt.Application.Handlers.Role;
using NoteIt.WebApi.Common;

namespace NoteIt.WebApi.Controllers;

public class RoleController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get(GetRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(GetAllRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}
