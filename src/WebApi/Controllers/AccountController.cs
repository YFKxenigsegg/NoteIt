using Microsoft.AspNetCore.Mvc;
using NoteIt.Application.Handlers.Account;
using NoteIt.WebApi.Common;

namespace NoteIt.WebApi.Controllers;
public class AccountController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}
