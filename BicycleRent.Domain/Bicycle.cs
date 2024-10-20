namespace BicycleRent.Domain;

public class Bicycle
{
    public required int IdBicycle { get; set; }

    public required string SerialNumber { get; set; }

    public required BicycleType Type { get; set; }

    public required string Model { get; set; }

    public required string Color { get; set; }
}
