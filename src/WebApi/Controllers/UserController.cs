using Microsoft.AspNetCore.Mvc;
using Note.Application.Handlers.User.Create;
using Note.WebApi.Common;

namespace Note.WebApi.Controllers;

public class UserController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}
