namespace BicycleRent.Domain;

/// <summary>
/// Класс для описания сущности "Аренда велосипеда"
/// </summary>
public class Rent
{
    /// <summary>
    /// ID аренды
    /// </summary>
    public required int PK_IdRent { get; set; }


    /// <summary>
    /// Арендатор
    /// </summary>
    public required BicycleRenter Renter { get; set; }


    /// <summary>
    /// Велосипед
    /// </summary>
    public required Bicycle Bicycle { get; set; }


    /// <summary>
    /// Время началы аренды
    /// </summary>
    public required TimeOnly TimeStart { get; set; }


    /// <summary>
    /// Время окончания аренды
    /// </summary>
    public required TimeOnly TimeEnd { get; set; }


    /// <summary>
    /// Время аренды
    /// </summary>
    public required int TimeRent { get; set; }
}
