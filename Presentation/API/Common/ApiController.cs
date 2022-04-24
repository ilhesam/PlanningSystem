using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API;

[Route("API/[area]/[controller]/[action]")]
[ApiController]
[TypeFilter(typeof(ResultFilter))]
public abstract class ApiController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
}