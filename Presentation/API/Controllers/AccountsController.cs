using Microsoft.AspNetCore.Mvc;
using Service;

namespace API;

[IdentificationArea]
public class AccountsController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Register(RegisterUser request, CancellationToken cancellationToken = default)
        => Ok(await Mediator.Send(request, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> Login(LoginUser request, CancellationToken cancellationToken = default)
        => Ok(await Mediator.Send(request, cancellationToken));
}