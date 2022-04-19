using Microsoft.AspNetCore.Mvc;
using Service;

namespace API;

[PlanningArea]
public class MetricsController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMetric request, CancellationToken cancellationToken = default)
        => Ok(await Mediator.Send(request, cancellationToken));

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMetric request, CancellationToken cancellationToken = default)
        => Ok(await Mediator.Send(request, cancellationToken));

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeleteMetric request, CancellationToken cancellationToken = default)
        => Ok(await Mediator.Send(request, cancellationToken));
}