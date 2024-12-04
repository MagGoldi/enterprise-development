using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;

namespace BicycleRent.Domain.Repositories.List;

public class RentRepository() : IRepository<Rent, int>
{
    private static readonly List<Rent> _rents = new BicycleRentDataSeeder().Rents;
    private static int _countRents = _rents.Count;


    /// <summary>
    /// Метод для получаения списка всех элементов в коллекции сущностей "Аренда Велосипеда"
    /// </summary>
    /// <returns>Список с элементами сущности "Аренда Велосипеда"</returns>
    public List<Rent> GetList()
    {
        return _rents;
    }


    /// <summary>
    /// Метод для получения элемента из коллекции сущностей "Аренда Велосипеда" по id
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <returns>Экземпляр сущности "Аренда Велосипеда"</returns>
    public Rent? GetItem(int id)
    {
        return _rents.Find(b => b.RentId == id);
    }


    /// <summary>
    /// Метод для добавления элемента в коллекцию сущностей "Аренда Велосипеда"
    /// </summary>
    /// <param name="newItem">Экзепляр сущности "Аренда Велосипеда" для добавления</param>
    public void AddItem(Rent newItem)
    {
        newItem.RentId = _countRents++;
        _rents.Add(newItem);
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
    public bool UpdateItem(int id, Rent newItemValue)
    {
        var rent = GetItem(id);
        if (rent == null)
            return false;
        rent.RentId = newItemValue.RentId;
        rent.Renter = newItemValue.Renter;
        rent.Bicycle = newItemValue.Bicycle;
        rent.TimeStart = newItemValue.TimeStart;
        rent.TimeEnd = newItemValue.TimeEnd;
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
    public bool DeleteItem(int id)
    {
        var rent = GetItem(id);

        if (rent == null)
            return false;

        _rents.Remove(rent);
        return true;
    }
}
