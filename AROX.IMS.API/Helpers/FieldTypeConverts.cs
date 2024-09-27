using AROX.IMS.API.Classes;
using IMS.EF.Models;

namespace AROX.IMS.API.Helpers;

public class FieldTypeConverts
{
    // Convert EF model to DTO
    public static FieldTypeDto FieldTypeToFieldTypeDto(FieldType fieldType)
    {
        return new FieldTypeDto
        {
            Id = fieldType.Id,
            Type = fieldType.Type
        };
    }

    // Convert DTO to EF model
    public static FieldType FieldTypeDtoToFieldType(NewFieldTypeDto fieldType)
    {
        return new FieldType
        {
            Type = fieldType.Type
        };
    }

    public static FieldType FieldTypeDtoToFieldType(FieldTypeDto fieldType)
    {
        return new FieldType
        {
            Id = fieldType.Id,
            Type = fieldType.Type
        };
    }

    // Update EF model with DTO
    public static void UpdateFieldType(FieldType fieldType, FieldTypeDto fieldTypeModel)
    {
        fieldType.Type = fieldTypeModel.Type;
    }
}