using AROX.IMS.API.Classes;
using IMS.EF.Models;

namespace AROX.IMS.API.Helpers;

public class ToolInputConverters
{
    // Convert EF model to DTO
    public static ToolInputDto ToModel(ToolInput toolInput)
    {
        return new ToolInputDto
        {
            Id = toolInput.Id,
            ToolId = toolInput.ToolId,
            FieldTypeId = toolInput.FieldTypeId,
            Name = toolInput.Name,
            Label = toolInput.Label,
            Placeholder = toolInput.Placeholder
        };
    }

    // Convert DTO to EF model
    public static ToolInput ToEntity(NewToolInputDto toolInput)
    {
        return new ToolInput
        {
            ToolId = toolInput.ToolId,
            FieldTypeId = toolInput.FieldTypeId,
            Name = toolInput.Name,
            Label = toolInput.Label,
            Placeholder = toolInput.Placeholder
        };
    }

    public static ToolInput ToEntity(ToolInputDto toolInput)
    {
        return new ToolInput
        {
            Id = toolInput.Id,
            ToolId = toolInput.ToolId,
            FieldTypeId = toolInput.FieldTypeId,
            Name = toolInput.Name,
            Label = toolInput.Label,
            Placeholder = toolInput.Placeholder
        };
    }

    // Update EF model with DTO
    public static void UpdateEntity(ToolInput toolInput, ToolInputDto toolInputModel)
    {
        toolInput.FieldTypeId = toolInputModel.FieldTypeId;
        toolInput.Name = toolInputModel.Name;
        toolInput.Label = toolInputModel.Label;
        toolInput.Placeholder = toolInputModel.Placeholder;
    }
}