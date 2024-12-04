namespace BicycleRent.Servicies.Dto;

/// <summary>
/// Класс-DTO для добавления/изменения сущности "Тип велосипеда"
/// </summary>
public class BicycleTypeDto
{
    /// <summary>
    /// ID типа велосипеда
    /// </summary>
    public required int TypeId { get; set; }

    /// <summary>
    /// Тип велиспеда
    /// </summary>
    public required string Type { get; set; }


    /// <summary>
    /// Цена оренды за час
    /// </summary>
    public required decimal Price { get; set; }
}
