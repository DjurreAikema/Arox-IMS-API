namespace AROX.IMS.API.Classes;

public class NewApplicationDto
{
    public long CustomerId { get; set; }

    public string Name { get; set; } = null!;
}

public class ApplicationDto
{
    public long Id { get; set; }
    public long CustomerId { get; set; }

    public string Name { get; set; } = null!;
}