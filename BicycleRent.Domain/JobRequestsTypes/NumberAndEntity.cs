
namespace BicycleRent.Domain.JobRequestsTypes;

/// <summary>
/// Класс для хранения пар значений (Число - Сущность ) для возвращения запросов из задания
/// </summary>
public class NumberAndEntity<Tkey, TEntity>
{
    public required Tkey Count { get; set; }

    public required TEntity EntityRent { get; set; }
}
