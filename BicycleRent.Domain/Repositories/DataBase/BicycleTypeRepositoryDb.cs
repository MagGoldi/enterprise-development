using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace BicycleRent.Domain.Repositories.Database;

/// <summary>
/// Класс для реализации CRUD операций для сущности "Тип велосипеда"
/// </summary>
public class BicycleTypeRepositoryDb(BicycleRentDbContext context) : IRepositoryDb<BicycleType, int>
{
    /// <summary>
    /// Метод для получаения списка всех элементов в коллекции сущностей "Тип велосипеда"
    /// </summary>
    /// <returns>Список с элементами сущности "Тип велосипеда"</returns>
    public async Task<List<BicycleType>> GetList()
    {
        return await context.BicycleTypes.ToListAsync();
    }


    /// <summary>
    /// Метод для получения элемента из коллекции сущностей "Тип велосипеда" по id
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <returns>Экземпляр сущности "Тип велосипеда"</returns>
    public async Task<BicycleType?> GetItem(int id)
    {
        return await context.BicycleTypes.FindAsync(id);
    }


    /// <summary>
    /// Метод для добавления элемента в коллекцию сущностей "Тип велосипеда"
    /// </summary>
    /// <param name="newItem">Экзепляр сущности "Тип велосипеда" для добавления</param>
    public async Task AddItem(BicycleType newItem)
    {
        await context.BicycleTypes.AddAsync(newItem);
        await context.SaveChangesAsync();
    }


    /// <summary>
    /// Метод для обновления элемента в коллекции сущностей "Тип велосипеда" по id
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <param name="newItemValue">Экзмепляр сущности "Тип велосипеда" для обновления</param>
    /// <returns>
    ///     true в случае удачного добавления
    ///     false в случае ошибки при удалении
    /// </returns>
    public async Task<bool> UpdateItem(int id, BicycleType newItemValue)
    {
        var type = await GetItem(id);
        if (type == null)
            return false;
        type.TypeId = newItemValue.TypeId;
        type.Type = newItemValue.Type;
        type.Price = newItemValue.Price;
        
        context.BicycleTypes.Update(type);
        await context.SaveChangesAsync();

        return true;
    }


    /// <summary>
    /// Метод для удаления элемента из коллекции сущностей "Тип велосипеда" по id 
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <returns>
    ///     true в случае удачного добавления
    ///     false в случае ошибки при удалении
    /// </returns>
    public async Task<bool> DeleteItem(int id)
    {
        var type = await GetItem(id);

        if (type == null)
            return false;

        context.BicycleTypes.Remove(type);
        await context.SaveChangesAsync();

        return true;
    }
}
