﻿using AROX.IMS.API.Classes;
using IMS.EF.Models;

namespace AROX.IMS.API.Helpers;

public class ToolConverters
{
    // Convert EF model to DTO
    public static ToolDto ToModel(Tool tool)
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
    public static Tool ToEntity(NewToolDto tool)
    {
        return new Tool
        {
            ApplicationId = tool.ApplicationId,
            Name = tool.Name,
            ApiEndpoint = tool.ApiEndpoint
        };
    }

    public static Tool ToEntity(ToolDto tool)
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
    public static void UpdateEntity(Tool tool, ToolDto toolModel)
    {
        tool.Name = toolModel.Name;
        tool.ApiEndpoint = toolModel.ApiEndpoint;
    }
}