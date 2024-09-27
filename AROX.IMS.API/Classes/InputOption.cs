namespace AROX.IMS.API.Classes;

public class InputOption
{
    public long Id { get; set; }
    public long InputId { get; set; }

    public string Label { get; set; } = null!;
    public string Value { get; set; } = null!;
}