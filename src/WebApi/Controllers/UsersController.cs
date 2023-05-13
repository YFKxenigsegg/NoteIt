using Microsoft.AspNetCore.Mvc;
using Note.Application.Users.Users;
using Note.WebApi.Common;

namespace Note.WebApi.Controllers;

public class UsersController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}
