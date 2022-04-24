namespace API;

public class ApiResponse
{
    public object Result { get; set; }

    public bool Succeeded { get; set; }
    public List<ApiError> Errors { get; set; }

    public string TraceIdentifier { get; set; }
    public double Duration { get; set; }
    public DateTime Time { get; set; }

    public string UserName { get; set; }
}

public class ApiError
{
    public string Code { get; set; }
    public string Description { get; set; }

    public ApiError()
    {
    }

    public ApiError(Exception exception)
    {
        Code = exception.Data.Contains("Code") ? exception.Data["Code"] as string : null;
        Description = exception.Message;
    }
}