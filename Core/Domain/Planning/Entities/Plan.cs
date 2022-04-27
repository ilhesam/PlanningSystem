namespace Core;

public class Plan : Entity, IHasOwner
{
    public string Title { get; set; }
    public string Description { get; set; }

    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public IEnumerable<Guid> Targets { get; set; }

    public string OwnerUserName { get; set; }
}