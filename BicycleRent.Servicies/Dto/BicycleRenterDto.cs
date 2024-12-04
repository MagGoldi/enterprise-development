namespace BicycleRent.Servicies.Dto;

/// <summary>
/// Класс-DTO для добавления/изменения сущности "Арендатор велосипеда"
/// </summary>
public class BicycleRenterDto
{
    /// <summary>
    /// ID арендатора велосипеда
    /// </summary>
    public required int RenterId { get; set; }

    /// <summary>
    /// ФИО арендатора
    /// </summary>
    public required string FullName { get; set; }


    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateOnly? BirthDate { get; set; }


    /// <summary>
    /// Номер телефона
    /// </summary>
    public string? PhoneNumber { get; set; }
}
