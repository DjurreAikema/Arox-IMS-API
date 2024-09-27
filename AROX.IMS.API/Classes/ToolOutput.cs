﻿namespace AROX.IMS.API.Classes;

public class ToolOutput
{
    public long Id { get; set; }
    public long ToolId { get; set; }
    public long FieldTypeId { get; set; }

    public string Name { get; set; } = null!;
}