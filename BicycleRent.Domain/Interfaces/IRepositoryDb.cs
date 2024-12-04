using System.Threading.Tasks;

namespace BicycleRent.Domain.Interfaces;

/// <summary>
/// Интерфейс для унифицирования CRUD операций для разных сущностей в базе данных
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
/// <typeparam name="Tkey">Тип индекса для досутпа к сущнности в коллекции</typeparam>
public interface IRepositoryDb<TEntity, Tkey>
{
    /// <summary>
    /// Метод для получаения списка всех элементов в коллекции
    /// </summary>
    /// <returns>Список с элементами данной сущности</returns>
    public Task<List<TEntity>> GetList();


    /// <summary>
    /// Метод для получения элемента из коллекции по id
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <returns>Экземпляр сущности сущности</returns>
    public Task<TEntity?> GetItem(Tkey id);


    /// <summary>
    /// Метод для добавления сущности в коллекцию
    /// </summary>
    /// <param name="newItem">Экзеплр сущности для добавления</param>
    public Task AddItem(TEntity newItem);


    /// <summary>
    /// Метод для обновления элемента в коллекции по id
    /// </summary>
    /// <param name="id">id элемента</param>
    /// <param name="newItemValue">Экзмепляр сущности для обновления</param>
    /// <returns>
    ///     true в случае удачного добавления
    ///     flase в случае ошибки при удалении
    /// </returns>
    public Task<bool> UpdateItem(Tkey id, TEntity newItemValue);


    /// <summary>
    /// Метод для удаления элемента из коллекции по id
    /// </summary>
    /// <param name="key">id элемента</param>
    /// <returns>
    ///     true в случае удачного добавления
    ///     flase в случае ошибки при удалении
    /// </returns>
    public Task<bool> DeleteItem(Tkey key);
}
