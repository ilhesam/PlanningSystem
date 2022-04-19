using Microsoft.AspNetCore.Mvc;
using Service;

namespace API;

[PlanningArea]
public class TargetsController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTarget request, CancellationToken cancellationToken = default)
        => Ok(await Mediator.Send(request, cancellationToken));

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTarget request, CancellationToken cancellationToken = default)
        => Ok(await Mediator.Send(request, cancellationToken));

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeleteTarget request, CancellationToken cancellationToken = default)
        => Ok(await Mediator.Send(request, cancellationToken));
}