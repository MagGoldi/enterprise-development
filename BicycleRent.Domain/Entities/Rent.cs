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
    [Column("renter")]
    public required BicycleRenter Renter { get; set; }

    [ForeignKey("renter_id")]
    [Column("renter_id")]
    public required int RenterId { get; set; }

    /// <summary>
    /// Велосипед
    /// </summary>
    [Column("bicycle")]
    public required Bicycle Bicycle { get; set; }

    [ForeignKey("bicycle_id")]
    [Column("bicycle_id")]
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
