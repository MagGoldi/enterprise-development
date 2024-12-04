using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BicycleRent.Domain.Repositories.Database;

/// <summary>
/// Класс для реализации CRUD операций для сущности "Арендатор велосипеда"
/// </summary>
public class BicycleRenterRepositoryDb(BicycleRentDbContext context) : IRepositoryDb<BicycleRenter, int>
{
    /// <summary>
    /// Метод для получаения списка всех элементов в коллекции сущностей "Арендатор велосипеда"
    /// </summary>
    /// <returns>Список с элементами сущности "Арендатор велосипеда"</returns>
    public async Task<List<BicycleRenter>> GetList()
    {
        return await context.BicycleRenters.ToListAsync();
    }


    /// <summary>
    /// Метод для получения элемента из коллекции сущностей "Арендатор велосипеда" по id
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <returns>Экземпляр сущности "ВелосиАрендатор велосипедапед"</returns>
    public async Task<BicycleRenter?> GetItem(int id)
    {
        return await context.BicycleRenters.FindAsync(id);
    }


    /// <summary>
    /// Метод для добавления элемента в коллекцию сущностей "Арендатор велосипеда"
    /// </summary>
    /// <param name="newItem">Экзепляр сущности "Арендатор велосипеда" для добавления</param>
    public async Task AddItem(BicycleRenter newItem)
    {
        await context.BicycleRenters.AddAsync(newItem);
        await context.SaveChangesAsync();
    }


    /// <summary>
    /// Метод для обновления элемента в коллекции сущностей "Арендатор велосипеда" по id
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <param name="newItemValue">Экзмепляр сущности "Арендатор велосипеда" для обновления</param>
    /// <returns>
    ///     true в случае удачного добавления
    ///     false в случае ошибки при удалении
    /// </returns>
    public async Task<bool> UpdateItem(int id, BicycleRenter newItemValue)
    {
        var renter = await GetItem(id);
        if (renter == null)
            return false;
        renter.RenterId = newItemValue.RenterId;
        renter.FullName = newItemValue.FullName;
        renter.BirthDate = newItemValue.BirthDate;
        renter.PhoneNumber = newItemValue.PhoneNumber;

        context.BicycleRenters.Update(renter);
        await context.SaveChangesAsync();

        return true;
    }


    /// <summary>
    /// Метод для удаления элемента из коллекции сущностей "Арендатор велосипеда" по id
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <returns>
    ///     true в случае удачного добавления
    ///     false в случае ошибки при удалении
    /// </returns>
    public async Task<bool> DeleteItem(int id)
    {
        var renter = await GetItem(id);

        if (renter == null)
            return false;

        context.BicycleRenters.Remove(renter);
        await context.SaveChangesAsync();

        return true;
    }
}
