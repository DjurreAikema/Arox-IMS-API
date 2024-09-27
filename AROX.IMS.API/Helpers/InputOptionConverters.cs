using AROX.IMS.API.Classes;
using IMS.EF.Models;

namespace AROX.IMS.API.Helpers;

public class InputOptionConverters
{
    // Convert EF model to DTO
    public static InputOptionDto InputOptionToInputOptionDto(InputOption inputOption)
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
    public static InputOption InputOptionDtoToInputOption(NewInputOptionDto inputOption)
    {
        return new InputOption
        {
            InputId = inputOption.InputId,
            Label = inputOption.Label,
            Value = inputOption.Value
        };
    }

    public static InputOption InputOptionDtoToInputOption(InputOptionDto inputOption)
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
    public static void UpdateInputOption(InputOption inputOption, InputOptionDto inputOptionModel)
    {
        inputOption.InputId = inputOptionModel.InputId;
        inputOption.Label = inputOptionModel.Label;
        inputOption.Value = inputOptionModel.Value;
    }
}