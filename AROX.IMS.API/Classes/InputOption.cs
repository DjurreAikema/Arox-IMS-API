namespace AROX.IMS.API.Classes;

public class InputOptionDto
{
    public long Id { get; set; }
    public long InputId { get; set; }

    public string Label { get; set; } = null!;
    public string Value { get; set; } = null!;
}