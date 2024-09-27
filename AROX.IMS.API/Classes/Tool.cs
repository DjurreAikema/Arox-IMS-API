namespace AROX.IMS.API.Classes;

public class NewToolDto
{
    public long ApplicationId { get; set; }

    public string Name { get; set; } = null!;
    public string ApiEndpoint { get; set; } = null!;
}

public class ToolDto
{
    public long Id { get; set; }
    public long ApplicationId { get; set; }

    public string Name { get; set; } = null!;
    public string ApiEndpoint { get; set; } = null!;
}