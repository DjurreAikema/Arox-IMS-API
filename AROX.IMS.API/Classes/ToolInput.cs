namespace AROX.IMS.API.Classes;

public class NewToolInputDto
{
    public long ToolId { get; set; }
    public long FieldTypeId { get; set; }

    public string Name { get; set; } = null!;
    public string Label { get; set; } = null!;
    public string? Placeholder { get; set; }
}

public class ToolInputDto
{
    public long Id { get; set; }
    public long ToolId { get; set; }
    public long FieldTypeId { get; set; }

    public string Name { get; set; } = null!;
    public string Label { get; set; } = null!;
    public string? Placeholder { get; set; }
}