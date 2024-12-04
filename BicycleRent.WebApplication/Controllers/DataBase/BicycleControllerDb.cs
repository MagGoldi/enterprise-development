using AutoMapper;
using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Servicies.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRent.WebApplication.Controllers.DataBase;

/// <summary>
/// Класс-контроллер для сущности "Велосипед"
/// </summary>
/// <param name="repository">Репозиторий сущности "Велосипед"</param>
/// <param name="mapper">Маппер</param>
[Route("api/[controller]")]
[ApiController]
public class BicycleControllerDb(IRepositoryDb<Bicycle, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получить все велосипеды
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BicycleDto>>> Get()
    {
        var repo = await repository.GetList();

        var get = mapper.Map<List<BicycleDto>>(repo);
        if (get.Count == 0)
            return NoContent();
        return Ok(get);
    }


    /// <summary>
    /// Получить велосипед по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<BicycleDto>> Get(int id)
    {
        var bicycle = await repository.GetItem(id);

        if (bicycle == null)
            return NoContent();

        var bicycleDto = mapper.Map<BicycleDto>(bicycle);

        return Ok(bicycleDto);
    }


    /// <summary>
    /// Добавить велосипед
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BicycleDto value)
    {
        var bicycle = mapper.Map<Bicycle>(value);
        await repository.AddItem(bicycle);
        return Ok();
    }


    /// <summary>
    /// Обновить велосипед по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] BicycleDto value)
    {
        var bicycle = mapper.Map<Bicycle>(value);
        var update = await repository.UpdateItem(id, bicycle);

        if (!update)
            return NoContent();

        var bicycleUpdate = repository.GetItem(id);
        var bicycleDto = mapper.Map<BicycleDto>(bicycleUpdate);

        return Ok(bicycleDto);
    }


    /// <summary>
    /// Удалить велосипед по id
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
