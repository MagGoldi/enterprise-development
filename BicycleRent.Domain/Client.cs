namespace BicycleRent.Domain;

public class Client
{
    public required int IdClient { get; set; }

    public required string FullName { get; set; }

    public required DateOnly BirthDate { get; set; }

    public required string PhoneNumber { get; set; }
}
