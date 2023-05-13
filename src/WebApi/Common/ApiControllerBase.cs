using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Note.WebApi.Common;
[ApiController]
[Route("api/[controller]/[action]")]
public class ApiControllerBase : ControllerBase
{
    private IMediator _mediator = null!;

    protected IMediator Mediator => (_mediator ??= HttpContext.RequestServices.GetService<IMediator>()!);
}
