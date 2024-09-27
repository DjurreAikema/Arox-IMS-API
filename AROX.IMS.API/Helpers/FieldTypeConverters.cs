using AROX.IMS.API.Classes;
using IMS.EF.Models;

namespace AROX.IMS.API.Helpers;

public class FieldTypeConverters
{
    // Convert EF model to DTO
    public static FieldTypeDto ToModel(FieldType fieldType)
    {
        return new FieldTypeDto
        {
            Id = fieldType.Id,
            Type = fieldType.Type
        };
    }

    // Convert DTO to EF model
    public static FieldType ToEntity(NewFieldTypeDto fieldType)
    {
        return new FieldType
        {
            Type = fieldType.Type
        };
    }

    public static FieldType ToEntity(FieldTypeDto fieldType)
    {
        return new FieldType
        {
            Id = fieldType.Id,
            Type = fieldType.Type
        };
    }

    // Update EF model with DTO
    public static void UpdateEntity(FieldType fieldType, FieldTypeDto fieldTypeModel)
    {
        fieldType.Type = fieldTypeModel.Type;
    }
}