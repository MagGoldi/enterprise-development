using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace BicycleRent.Domain.Repositories.Database;

public class RentRepositoryDb(BicycleRentDbContext context) : IRepositoryDb<Rent, int>
{
    /// <summary>
    /// Метод для получаения списка всех элементов в коллекции сущностей "Аренда Велосипеда"
    /// </summary>
    /// <returns>Список с элементами сущности "Аренда Велосипеда"</returns>
    public async Task<List<Rent>> GetList()
    {
        return await context.Rents.Include(b => b.Renter).Include(b => b.Bicycle).ThenInclude(b => b.Type).ToListAsync();
    }


    /// <summary>
    /// Метод для получения элемента из коллекции сущностей "Аренда Велосипеда" по id
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <returns>Экземпляр сущности "Аренда Велосипеда"</returns>
    public async Task<Rent?> GetItem(int id)
    {
        return await context.Rents.FindAsync(id);
    }


    /// <summary>
    /// Метод для добавления элемента в коллекцию сущностей "Аренда Велосипеда"
    /// </summary>
    /// <param name="newItem">Экзепляр сущности "Аренда Велосипеда" для добавления</param>
    public async Task AddItem(Rent newItem)
    {
        await context.Rents.AddAsync(newItem);
        await context.SaveChangesAsync();
    }


    /// <summary>
    /// Метод для обновления элемента в коллекции сущностей "Аренда Велосипеда" по id
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <param name="newItemValue">Экзмепляр сущности "Аренда Велосипеда" для обновления</param>
    /// <returns>
    ///     true в случае удачного добавления
    ///     false в случае ошибки при удалении
    /// </returns>
    public async Task<bool> UpdateItem(int id, Rent newItemValue)
    {
        var rent = await GetItem(id);
        if (rent == null)
            return false;
        rent.RentId = newItemValue.RentId;
        rent.Renter = newItemValue.Renter;
        rent.RentId = newItemValue.RenterId;
        rent.Bicycle = newItemValue.Bicycle;
        rent.BicycleId = newItemValue.BicycleId;
        rent.TimeStart = newItemValue.TimeStart;
        rent.TimeEnd = newItemValue.TimeEnd;

        context.Rents.Update(rent);
        await context.SaveChangesAsync();

        return true;
    }


    /// <summary>
    /// Метод для удаления элемента из коллекции сущностей "Аренда Велосипеда" по id
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <returns>
    ///     true в случае удачного добавления
    ///     false в случае ошибки при удалении
    /// </returns>
    public async Task<bool> DeleteItem(int id)
    {
        var rent = await GetItem(id);

        if (rent == null)
            return false;

        context.Rents.Remove(rent);
        await context.SaveChangesAsync();

        return true;
    }
}
