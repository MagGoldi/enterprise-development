using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace BicycleRent.Domain.Repositories.Database;

/// <summary>
///  Класс для реализации CRUD операций для сущности "Велосипед"
/// </summary>
public class BicycleRepositoryDb(BicycleRentDbContext context) : IRepositoryDb<Bicycle, int>
{
    /// <summary> 
    /// Метод для получаения списка всех элементов в коллекции сущностей "Велосипед"
    /// </summary>
    /// <returns>Список с элементами сущности "Велосипед"</returns>
    public async Task<List<Bicycle>> GetList()
    {
        return await context.Bicycles.Include(b => b.Type).ToListAsync();
    }


    /// <summary>
    /// Метод для получения элемента из коллекции сущностей "Велосипед" по id
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <returns>Экземпляр сущности "Велосипед"</returns>
    public async Task<Bicycle?> GetItem(int id)
    {
        return await context.Bicycles.FindAsync(id);
    }


    /// <summary>
    /// Метод для добавления элемента в коллекцию сущностей "Велосипед"
    /// </summary>
    /// <param name="newItem">Экзепляр сущности "Велосипед" для добавления</param>
    public async Task AddItem(Bicycle newItem)
    {
        await context.Bicycles.AddAsync(newItem);
        await context.SaveChangesAsync();
    }


    /// <summary>
    /// Метод для обновления элемента в коллекции сущностей "Велосипед" по id
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <param name="newItemValue">Экзмепляр сущности "Велосипед" для обновления</param>
    /// <returns>
    ///     true в случае удачного добавления
    ///     false в случае ошибки при удалении
    /// </returns>
    public async Task<bool> UpdateItem(int id, Bicycle newItemValue)
    {
        var bicycle = await GetItem(id);
        if (bicycle == null)
            return false;
        bicycle.BicycleId = newItemValue.BicycleId;
        bicycle.SerialNumber = newItemValue.SerialNumber;
        bicycle.Type = newItemValue.Type;
        bicycle.TypeId = newItemValue.TypeId;
        bicycle.Model = newItemValue.Model;
        bicycle.Color = newItemValue.Color;

        context.Bicycles.Update(bicycle);
        await context.SaveChangesAsync();
        return true;
    }


    /// <summary>
    /// Метод для удаления элемента из коллекции сущностей "Велосипед" по id
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <returns>
    ///     true в случае удачного добавления
    ///     false в случае ошибки при удалении
    /// </returns>
    public async Task<bool> DeleteItem(int id)
    {
        var bicycle = await GetItem(id);

        if (bicycle == null)
            return false;

        context.Bicycles.Remove(bicycle);
        await context.SaveChangesAsync();

        return true;
    }
}
