using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BicycleRent.Domain.Entities;

/// <summary>
/// Класс для описания сущности "Аренда велосипеда"
/// </summary>
[Table("rents")]
public class Rent
{
    /// <summary>
    /// ID аренды
    /// </summary>
    [Key]
    [Column("rent_id")]
    public required int RentId { get; set; }


    /// <summary>
    /// Арендатор
    /// </summary>
    public BicycleRenter Renter { get; set; }

    
    [Column("renter_id")]
    [Required]
    public required int RenterId { get; set; }

    /// <summary>
    /// Велосипед
    /// </summary>
    public Bicycle Bicycle { get; set; }

    [Column("bicycle_id")]
    [Required]
    public required int BicycleId { get; set; }

    /// <summary>
    /// Время началы аренды
    /// </summary>
    [Column("time_start")]
    public DateTime? TimeStart { get; set; }


    /// <summary>
    /// Время окончания аренды
    /// </summary>
    [Column("time_end")]
    public DateTime? TimeEnd { get; set; }


    /// <summary>
    /// Время аренды
    /// </summary>

    [Column("time_rent")]
    public TimeSpan TimeRent => TimeStart.HasValue && TimeEnd.HasValue ? TimeEnd.Value.Subtract(TimeStart.Value) : TimeSpan.Zero;
}
