using Microsoft.AspNetCore.Mvc;

namespace API;

public class IdentificationAreaAttribute : AreaAttribute
{
    public IdentificationAreaAttribute() : base("Identification")
    {
    }
}

public class PlanningAreaAttribute : AreaAttribute
{
    public PlanningAreaAttribute() : base("Planning")
    {
    }
}