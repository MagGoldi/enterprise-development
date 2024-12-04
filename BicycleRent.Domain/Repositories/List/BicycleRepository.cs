using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;

namespace BicycleRent.Domain.Repositories.List;

/// <summary>
///  Класс для реализации CRUD операций для сущности "Велосипед"
/// </summary>
public class BicycleRepository() : IRepository<Bicycle, int>
{
    private static readonly List<Bicycle> _bicycles = new BicycleRentDataSeeder().Bicycles;
    private static int _countBicycles = _bicycles.Count;


    /// <summary>
    /// Метод для получаения списка всех элементов в коллекции сущностей "Велосипед"
    /// </summary>
    /// <returns>Список с элементами сущности "Велосипед"</returns>
    public List<Bicycle> GetList()
    {
        return _bicycles;
    }


    /// <summary>
    /// Метод для получения элемента из коллекции сущностей "Велосипед" по id
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <returns>Экземпляр сущности "Велосипед"</returns>
    public Bicycle? GetItem(int id)
    {
        return _bicycles.Find(b => b.BicycleId == id);
    }


    /// <summary>
    /// Метод для добавления элемента в коллекцию сущностей "Велосипед"
    /// </summary>
    /// <param name="newItem">Экзепляр сущности "Велосипед" для добавления</param>
    public void AddItem(Bicycle newItem)
    {
        newItem.BicycleId = _countBicycles++;
        _bicycles.Add(newItem);
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
    public bool UpdateItem(int id, Bicycle newItemValue)
    {
        var bicycle = GetItem(id);
        if (bicycle == null)
            return false;
        bicycle.BicycleId = newItemValue.BicycleId;
        bicycle.SerialNumber = newItemValue.SerialNumber;
        bicycle.Type = newItemValue.Type;
        bicycle.Model = newItemValue.Model;
        bicycle.Color = newItemValue.Color;
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
    public bool DeleteItem(int id)
    {
        var bicycle = GetItem(id);

        if (bicycle == null)
            return false;

        _bicycles.Remove(bicycle);
        return true;
    }
}
