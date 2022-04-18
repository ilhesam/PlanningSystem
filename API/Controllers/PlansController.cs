using Microsoft.AspNetCore.Mvc;
using Service;

namespace API;

[PlanningArea]
public class PlansController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePlan request, CancellationToken cancellationToken = default)
        => Ok(await Mediator.Send(request, cancellationToken));

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePlan request, CancellationToken cancellationToken = default)
        => Ok(await Mediator.Send(request, cancellationToken));

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeletePlan request, CancellationToken cancellationToken = default)
        => Ok(await Mediator.Send(request, cancellationToken));
}