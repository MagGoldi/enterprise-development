namespace BicycleRent.Domain;

/// <summary>
/// Класс для описания сущности "Велосипед"
/// </summary>
public class Bicycle
{
    /// <summary>
    /// ID велосипеда - первичный ключ
    /// </summary>
    public required int PK_IdBicycle { get; set; }


    /// <summary>
    /// Серийный номер
    /// </summary>
    public required string SerialNumber { get; set; }


    /// <summary>
    /// Тип велосипеда
    /// </summary>
    public required BicycleType Type { get; set; }


    /// <summary>
    /// Модель велосипеда
    /// </summary>
    public required string Model { get; set; }


    /// <summary>
    /// Цвет велосипеда
    /// </summary>
    public required string Color { get; set; }
}
