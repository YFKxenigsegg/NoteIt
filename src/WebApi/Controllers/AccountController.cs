﻿using Microsoft.AspNetCore.Mvc;
using Note.Application.Users.Users.Register;
using Note.WebApi.Common;

namespace Note.WebApi.Controllers;

public class AccountController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}
