using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;

namespace BicycleRent.Domain.Repositories.List;

/// <summary>
/// Класс для реализации CRUD операций для сущности "Тип велосипеда"
/// </summary>
public class BicycleTypeRepository() : IRepository<BicycleType, int>
{
    private static readonly List<BicycleType> _bicycleTypes = new BicycleRentDataSeeder().BicycleTypes;
    private static int _countBicycleTypes = _bicycleTypes.Count;


    /// <summary>
    /// Метод для получаения списка всех элементов в коллекции сущностей "Тип велосипеда"
    /// </summary>
    /// <returns>Список с элементами сущности "Тип велосипеда"</returns>
    public List<BicycleType> GetList()
    {
        return _bicycleTypes;
    }


    /// <summary>
    /// Метод для получения элемента из коллекции сущностей "Тип велосипеда" по id
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <returns>Экземпляр сущности "Тип велосипеда"</returns>
    public BicycleType? GetItem(int id)
    {
        return _bicycleTypes.Find(bT => bT.TypeId == id);
    }


    /// <summary>
    /// Метод для добавления элемента в коллекцию сущностей "Тип велосипеда"
    /// </summary>
    /// <param name="newItem">Экзепляр сущности "Тип велосипеда" для добавления</param>
    public void AddItem(BicycleType newItem)
    {
        newItem.TypeId = _countBicycleTypes++;
        _bicycleTypes.Add(newItem);
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
    public bool UpdateItem(int id, BicycleType newItemValue)
    {
        var type = GetItem(id);
        if (type == null)
            return false;
        type.TypeId = newItemValue.TypeId;
        type.Type = newItemValue.Type;
        type.Price = newItemValue.Price;
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
    public bool DeleteItem(int id)
    {
        var type = GetItem(id);

        if (type == null)
            return false;

        _bicycleTypes.Remove(type);
        return true;
    }
}
