namespace AROX.IMS.API.Classes;

public class NewToolOutputDto
{
    public long ToolId { get; set; }
    public long FieldTypeId { get; set; }

    public string Name { get; set; } = null!;
}

public class ToolOutputDto
{
    public long Id { get; set; }
    public long ToolId { get; set; }
    public long FieldTypeId { get; set; }

    public string Name { get; set; } = null!;
}