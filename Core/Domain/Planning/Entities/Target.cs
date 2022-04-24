namespace Core;

public class Target : Entity, IHasOwner
{
    public string Title { get; set; }
    public string Description { get; set; }

    public virtual object PlanId { get; set; }
    public virtual object MetricId { get; set; }

    public double Progress { get; set; }

    public string OwnerUserName { get; set; }
}