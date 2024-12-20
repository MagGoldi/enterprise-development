namespace BicycleRent.Servicies.Dto;

/// <summary>
/// Класс-DTO для добавления/изменения сущности "Велосипед"
/// </summary>
public class BicycleDto
{
    /// <summary>
    /// ID велосипеда
    /// </summary>
    public required int BicycleId { get; set; }


    /// <summary>
    /// Серийный номер
    /// </summary>
    public required string SerialNumber { get; set; }


    /// <summary>
    /// id типа велосипеда
    /// </summary>
    public required int TypeId { get; set; }


    /// <summary>
    /// Модель велосипеда
    /// </summary>
    public string? Model { get; set; }


    /// <summary>
    /// Цвет велосипеда
    /// </summary>
    public string? Color { get; set; }
}
