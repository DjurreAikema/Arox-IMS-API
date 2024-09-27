namespace AROX.IMS.API.Classes;

public class ToolModel
{
    public long Id { get; set; }
    public long ApplicationId { get; set; }

    public string Name { get; set; } = null!;
    public string ApiEndpoint { get; set; } = null!;
}