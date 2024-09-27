using AROX.IMS.API.Classes;
using IMS.EF.Models;

namespace AROX.IMS.API.Helpers;

public class ToolOutputConverters
{
    // Convert EF model to DTO
    public static ToolOutputDto ToModel(ToolOutput toolOutput)
    {
        return new ToolOutputDto
        {
            Id = toolOutput.Id,
            ToolId = toolOutput.ToolId,
            FieldTypeId = toolOutput.FieldTypeId,
            Name = toolOutput.Name,
        };
    }

    // Convert DTO to EF model
    public static ToolOutput ToEntity(NewToolOutputDto toolOutput)
    {
        return new ToolOutput
        {
            ToolId = toolOutput.ToolId,
            FieldTypeId = toolOutput.FieldTypeId,
            Name = toolOutput.Name,
        };
    }

    public static ToolOutput ToEntity(ToolOutputDto toolOutput)
    {
        return new ToolOutput
        {
            Id = toolOutput.Id,
            ToolId = toolOutput.ToolId,
            FieldTypeId = toolOutput.FieldTypeId,
            Name = toolOutput.Name,
        };
    }

    // Update EF model with DTO
    public static void UpdateEntity(ToolOutput toolOutput, ToolOutputDto toolOutputModel)
    {
        toolOutput.ToolId = toolOutputModel.ToolId;
        toolOutput.FieldTypeId = toolOutputModel.FieldTypeId;
        toolOutput.Name = toolOutputModel.Name;
    }
}