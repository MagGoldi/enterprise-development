using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BicycleRent.Domain.Entities;

/// <summary>
/// Класс для описания сущности "Тип велосипеда"
/// </summary>
[Table("bicycle_types")]
public class BicycleType
{
    /// <summary>
    /// ID типа - первичный ключ
    /// </summary>
    [Key]
    [Column("type_id")]
    public required int TypeId { get; set; }


    /// <summary>
    /// Тип велиспеда
    /// </summary>
    [Column("type")]
    public required string Type { get; set; }


    /// <summary>
    /// Цена оренды за час
    /// </summary>
    [Column("price")]
    public required decimal Price { get; set; }


}
