using AutoMapper;
using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Servicies.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRent.WebApplication.Controllers.DataBase;

/// <summary>
/// Класс-контроллер для сущности "Тип велосипеда"
/// </summary>
/// <param name="repository">Репозиторий сущности "Тип велосипеда"</param>
/// <param name="mapper">Маппер</param>
[Route("api/[controller]")]
[ApiController]
public class BicycleTypeDbController(IRepositoryDb<BicycleType, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получить все типы велосипедов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BicycleTypeDto>>> Get()
    {
        var repo = await repository.GetList();
        var get = mapper.Map<List<BicycleTypeDto>>(repo);
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
    public async Task<ActionResult<BicycleTypeDto>> Get(int id)
    {
        var type = await repository.GetItem(id);

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
    public async Task<IActionResult> Post([FromBody] BicycleTypeDto value)
    {
        var type = mapper.Map<BicycleType>(value);
        await repository.AddItem(type);
        return Ok();
    }


    /// <summary>
    /// Обновить тип велосипеда по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] BicycleTypeDto value)
    {
        var type = mapper.Map<BicycleType>(value);
        var update = await repository.UpdateItem(id, type);

        if (!update)
            return NoContent();

        var typeUpdate = repository.GetItem(id);
        var typeDto = mapper.Map<BicycleTypeDto>(typeUpdate);

        return Ok(typeDto);
    }


    /// <summary>
    /// Удалить тип велосипеда по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var delete = await repository.DeleteItem(id);

        if (!delete)
            return NoContent();
        return Ok();
    }
}
