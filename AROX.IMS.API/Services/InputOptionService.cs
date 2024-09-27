using AROX.IMS.API.Classes;
using AROX.IMS.API.Exceptions;
using AROX.IMS.API.Helpers;
using IMS.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AROX.IMS.API.Services;

public class InputOptionService(AROX_IMSContext context)
{
    // Get all input options
    public async Task<List<InputOptionDto>> GetInputOptions()
    {
        return await context.InputOptions
            .Select(x => InputOptionConverters.ToModel(x))
            .ToListAsync();
    }

    // Get input option by id
    public async Task<InputOptionDto?> GetInputOption(long id)
    {
        return await context.InputOptions
            .Where(x => x.Id == id)
            .Select(x => InputOptionConverters.ToModel(x))
            .FirstOrDefaultAsync();
    }

    // Add new input option
    public async Task<InputOptionDto> AddInputOption(NewInputOptionDto inputOption)
    {
        // Validate
        await NotFoundException.EnsureToolInputExists(context, inputOption.InputId);

        // Add
        var newInputOption = InputOptionConverters.ToEntity(inputOption);
        context.InputOptions.Add(newInputOption);
        await context.SaveChangesAsync();

        // Return
        return InputOptionConverters.ToModel(newInputOption);
    }

    // Update input option
    public async Task<InputOptionDto> UpdateInputOption(InputOptionDto inputOption)
    {
        // Validate
        var existingInputOption = await NotFoundException.EnsureInputOptionExists(context, inputOption.Id);
        await NotFoundException.EnsureToolInputExists(context, inputOption.InputId);

        // Update
        InputOptionConverters.UpdateEntity(existingInputOption, inputOption);
        context.Entry(existingInputOption).State = EntityState.Modified;
        await context.SaveChangesAsync();

        // Return
        return InputOptionConverters.ToModel(existingInputOption);
    }

    // Delete input option
    public async Task<InputOptionDto> DeleteInputOption(long id)
    {
        // Validate
        var existingInputOption = await NotFoundException.EnsureInputOptionExists(context, id);

        // Delete
        context.InputOptions.Remove(existingInputOption);
        await context.SaveChangesAsync();

        // Return
        return InputOptionConverters.ToModel(existingInputOption);
    }
}