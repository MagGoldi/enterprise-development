using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BicycleRent.Domain.Entities;

/// <summary>
/// Класс для описания сущности "Арендатор"
/// </summary>
[Table("bicycle_renters")]
public class BicycleRenter
{
    /// <summary>
    /// ID арендатора
    /// </summary>
    [Key]
    [Column("renter_id")]
    public required int RenterId { get; set; }


    /// <summary>
    /// ФИО арендатора
    /// </summary>
    [Column("full_name")]
    public required string FullName { get; set; }


    /// <summary>
    /// Дата рождения
    /// </summary>
    [Column("id_bicycle")]
    public DateOnly? BirthDate { get; set; }


    /// <summary>
    /// Номер телефона
    /// </summary>
    [Column("phone_number")]
    public string? PhoneNumber { get; set; }
}
