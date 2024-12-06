using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BicycleRent.Domain.Entities;

/// <summary>
/// Класс для описания сущности "Велосипед"
/// </summary>
[Table("bicycles")]
public class Bicycle
{
    /// <summary>
    /// ID велосипеда - первичный ключ
    /// </summary>
    [Key]
    [Column("bicycle_id")]
    public required int BicycleId { get; set; }


    /// <summary>
    /// Серийный номер
    /// </summary>
    [Column("serial_number")]
    public required string SerialNumber { get; set; }


    /// <summary>
    /// Тип велосипеда
    /// </summary>
    public  BicycleType Type { get; set; }

    [Column("type_id")]
    public required int TypeId { get; set; }


    /// <summary>
    /// Модель велосипеда
    /// </summary>
    [Column("model")]
    public string? Model { get; set; }


    /// <summary>
    /// Цвет велосипеда
    /// </summary>
    [Column("color")]
    public string? Color { get; set; }
}
