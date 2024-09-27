using AROX.IMS.API.Classes;
using IMS.EF.Models;

namespace AROX.IMS.API.Helpers;

public class ToolConverters
{
    // Convert EF model to DTO
    public static ToolDto ToolToToolDto(Tool tool)
    {
        return new ToolDto
        {
            Id = tool.Id,
            ApplicationId = tool.ApplicationId,
            Name = tool.Name,
            ApiEndpoint = tool.ApiEndpoint
        };
    }

    // Convert DTO to EF model
    public static Tool ToolDtoToTool(NewToolDto tool)
    {
        return new Tool
        {
            ApplicationId = tool.ApplicationId,
            Name = tool.Name,
            ApiEndpoint = tool.ApiEndpoint
        };
    }

    public static Tool ToolDtoToTool(ToolDto tool)
    {
        return new Tool
        {
            Id = tool.Id,
            ApplicationId = tool.ApplicationId,
            Name = tool.Name,
            ApiEndpoint = tool.ApiEndpoint
        };
    }

    // Update EF model with DTO
    public static void UpdateTool(Tool tool, ToolDto toolModel)
    {
        tool.ApplicationId = toolModel.ApplicationId;
        tool.Name = toolModel.Name;
        tool.ApiEndpoint = toolModel.ApiEndpoint;
    }
}