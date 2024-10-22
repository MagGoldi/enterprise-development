namespace BicycleRent.Domain;

/// <summary>
/// Класс для описания сущности "Арендатор"
/// </summary>
public class BicycleRenter
{
    /// <summary>
    /// ID арендатора
    /// </summary>
    public required int PK_IdRenter { get; set; }


    /// <summary>
    /// ФИО арендатора
    /// </summary>
    public required string FullName { get; set; }


    /// <summary>
    /// Дата рождения
    /// </summary>
    public required DateOnly BirthDate { get; set; }


    /// <summary>
    /// Номер телефона
    /// </summary>
    public required string PhoneNumber { get; set; }
}
