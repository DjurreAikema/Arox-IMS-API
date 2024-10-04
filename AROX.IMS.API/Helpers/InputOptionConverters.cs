using AROX.IMS.API.Classes;
using IMS.EF.Models;

namespace AROX.IMS.API.Helpers;

public class InputOptionConverters
{
    // Convert EF model to DTO
    public static InputOptionDto ToModel(InputOption inputOption)
    {
        return new InputOptionDto
        {
            Id = inputOption.Id,
            InputId = inputOption.InputId,
            Label = inputOption.Label,
            Value = inputOption.Value
        };
    }

    // Convert DTO to EF model
    public static InputOption ToEntity(NewInputOptionDto inputOption)
    {
        return new InputOption
        {
            InputId = inputOption.InputId,
            Label = inputOption.Label,
            Value = inputOption.Value
        };
    }

    public static InputOption ToEntity(InputOptionDto inputOption)
    {
        return new InputOption
        {
            Id = inputOption.Id,
            InputId = inputOption.InputId,
            Label = inputOption.Label,
            Value = inputOption.Value
        };
    }

    // Update EF model with DTO
    public static void UpdateEntity(InputOption inputOption, InputOptionDto inputOptionModel)
    {
        inputOption.Label = inputOptionModel.Label;
        inputOption.Value = inputOptionModel.Value;
    }
}