using AROX.IMS.API.Classes;
using AROX.IMS.API.Exceptions;
using AROX.IMS.API.Helpers;
using IMS.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AROX.IMS.API.Services;

public class FieldTypeService(AROX_IMSContext context)
{
    // Get all field types
    public async Task<List<FieldTypeDto>> GetFieldTypes()
    {
        return await context.FieldTypes
            .Select(x => FieldTypeConverters.ToModel(x))
            .ToListAsync();
    }

    // Get field type by id
    public async Task<FieldTypeDto?> GetFieldType(long id)
    {
        return await context.FieldTypes
            .Where(x => x.Id == id)
            .Select(x => FieldTypeConverters.ToModel(x))
            .FirstOrDefaultAsync();
    }

    // Add new field type
    public async Task<FieldTypeDto> AddFieldType(NewFieldTypeDto fieldType)
    {
        // Add
        var newFieldType = FieldTypeConverters.ToEntity(fieldType);
        context.FieldTypes.Add(newFieldType);
        await context.SaveChangesAsync();

        // Return
        return FieldTypeConverters.ToModel(newFieldType);
    }

    // Update field type
    public async Task<FieldTypeDto> UpdateFieldType(FieldTypeDto fieldType)
    {
        // Validate
        var existingFieldType = await NotFoundException.EnsureFieldTypeExists(context, fieldType.Id);

        // Update
        FieldTypeConverters.UpdateEntity(existingFieldType, fieldType);
        context.Entry(existingFieldType).State = EntityState.Modified;
        await context.SaveChangesAsync();

        // Return
        return FieldTypeConverters.ToModel(existingFieldType);
    }

    // Delete field type
    public async Task<FieldTypeDto> DeleteFieldType(long id)
    {
        // Validate
        var existingFieldType = await NotFoundException.EnsureFieldTypeExists(context, id);

        // Delete
        context.FieldTypes.Remove(existingFieldType);
        await context.SaveChangesAsync();

        // Return
        return FieldTypeConverters.ToModel(existingFieldType);
    }
}