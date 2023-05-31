using Microsoft.AspNetCore.Mvc;
using NoteIt.Application.Handlers.User;
using NoteIt.WebApi.Common;

namespace NoteIt.WebApi.Controllers;

public class UserController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}
