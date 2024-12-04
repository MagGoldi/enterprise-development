using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;

namespace BicycleRent.Domain.Repositories.List;

/// <summary>
/// Класс для реализации CRUD операций для сущности "Арендатор велосипеда"
/// </summary>
public class BicycleRenterRepository() : IRepository<BicycleRenter, int>
{
    private static readonly List<BicycleRenter> _renters = new BicycleRentDataSeeder().Renters;
    private static int _countRenters = _renters.Count;


    /// <summary>
    /// Метод для получаения списка всех элементов в коллекции сущностей "Арендатор велосипеда"
    /// </summary>
    /// <returns>Список с элементами сущности "Арендатор велосипеда"</returns>
    public List<BicycleRenter> GetList()
    {
        return _renters;
    }


    /// <summary>
    /// Метод для получения элемента из коллекции сущностей "Арендатор велосипеда" по id
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <returns>Экземпляр сущности "ВелосиАрендатор велосипедапед"</returns>
    public BicycleRenter? GetItem(int id)
    {
        return _renters.Find(b => b.RenterId == id);
    }


    /// <summary>
    /// Метод для добавления элемента в коллекцию сущностей "Арендатор велосипеда"
    /// </summary>
    /// <param name="newItem">Экзепляр сущности "Арендатор велосипеда" для добавления</param>
    public void AddItem(BicycleRenter newItem)
    {
        newItem.RenterId = _countRenters++;
        _renters.Add(newItem);
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
    public bool UpdateItem(int id, BicycleRenter newItemValue)
    {
        var renter = GetItem(id);
        if (renter == null)
            return false;
        renter.RenterId = newItemValue.RenterId;
        renter.FullName = newItemValue.FullName;
        renter.BirthDate = newItemValue.BirthDate;
        renter.PhoneNumber = newItemValue.PhoneNumber;
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
    public bool DeleteItem(int id)
    {
        var renter = GetItem(id);

        if (renter == null)
            return false;

        _renters.Remove(renter);
        return true;
    }
}
