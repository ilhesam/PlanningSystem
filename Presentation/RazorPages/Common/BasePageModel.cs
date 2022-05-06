using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages;

public abstract class BasePageModel : PageModel
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
}