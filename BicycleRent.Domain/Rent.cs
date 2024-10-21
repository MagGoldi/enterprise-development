namespace BicycleRent.Domain;

public class Rent
{
    public required int IdRent { get; set; }

    public required Client Client { get; set; }

    public required Bicycle Bicycle { get; set; }

    public required TimeOnly TimeStart { get; set; }

    public required TimeOnly TimeEnd { get; set; }

    public required int TimeRent { get; set; }
}
