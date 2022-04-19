namespace Domain;

public class Target : Entity, IHasOwner
{
    public string Title { get; set; }
    public string Description { get; set; }

    public virtual Metric Metric { get; set; }
    public double Progress { get; set; }

    public string OwnerUserName { get; set; }
}