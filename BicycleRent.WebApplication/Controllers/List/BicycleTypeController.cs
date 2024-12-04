using AutoMapper;
using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Servicies.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRent.WebApplication.Controllers.List;

/// <summary>
/// Класс-контроллер для сущности "Тип велосипеда"
/// </summary>
/// <param name="repository">Репозиторий сущности "Тип велосипеда"</param>
/// <param name="mapper">Маппер</param>
[Route("api/[controller]")]
[ApiController]
public class BicycleTypeController(IRepository<BicycleType, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получить все типы велосипедов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<BicycleTypeDto>> Get()
    {
        var get = mapper.Map<List<BicycleTypeDto>>(repository.GetList());
        if (get.Count == 0)
            return NoContent();
        return Ok(get);
    }


    /// <summary>
    /// Получить тип велосипеда по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<BicycleType> Get(int id)
    {
        var type = repository.GetItem(id);

        if (type == null)
            return NoContent();
        var typeDto = mapper.Map<BicycleTypeDto>(type);

        return Ok(typeDto);
    }


    /// <summary>
    /// Добавить тип велосипеда
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] BicycleTypeDto value)
    {
        var type = mapper.Map<BicycleType>(value);
        repository.AddItem(type);
        return Ok();
    }


    /// <summary>
    /// Обновить тип велосипеда по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] BicycleTypeDto value)
    {
        var type = mapper.Map<BicycleType>(value);

        if (!repository.UpdateItem(id, type))
            return NoContent();

        var typeDto = mapper.Map<BicycleTypeDto>(repository.GetItem(id));

        return Ok(typeDto);
    }


    /// <summary>
    /// Удалить тип велосипеда по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.DeleteItem(id))
            return NoContent();
        return Ok();
    }
}
