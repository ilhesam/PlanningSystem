namespace Core;

public class Target : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }

    public Guid Plan { get; set; }
    public Guid SublimeTarget { get; set; }
    public Guid Metric { get; set; }

    public double Goal { get; set; }
    public double Progress { get; set; }
}