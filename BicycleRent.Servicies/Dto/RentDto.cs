namespace BicycleRent.Servicies.Dto;

/// <summary>
/// Класс-DTO для добавления/изменения сущности "Аренда велосипеда"
/// </summary>
public class RentDto
{
    /// <summary>
    /// ID аренды
    /// </summary>
    public required int RentId { get; set; }


    /// <summary>
    /// id арендатора
    /// </summary>
    public required int RenterId { get; set; }


    /// <summary>
    /// id велосипеда
    /// </summary>
    public required int BicycleId { get; set; }


    /// <summary>
    /// Время началы аренды
    /// </summary>
    public required DateTime TimeStart { get; set; }


    /// <summary>
    /// Время окончания аренды
    /// </summary>
    public required DateTime TimeEnd { get; set; }
}
