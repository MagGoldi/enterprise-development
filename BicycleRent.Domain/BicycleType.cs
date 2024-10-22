namespace BicycleRent.Domain;

/// <summary>
/// Класс для описания сущности "Тип велосипеда"
/// </summary>
public class BicycleType
{
    /// <summary>
    /// ID типа - первичный ключ
    /// </summary>
    public required int PK_IdType { get; set; }


    /// <summary>
    /// Тип велиспеда
    /// </summary>
    public required string Type { get; set; }


    /// <summary>
    /// Цена оренды за час
    /// </summary>
    public required double Price { get; set; }


}
