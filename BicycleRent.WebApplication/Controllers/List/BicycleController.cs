using AutoMapper;
using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Servicies.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRent.WebApplication.Controllers.List;

/// <summary>
/// Класс-контроллер для сущности "Велосипед"
/// </summary>
/// <param name="repository">Репозиторий сущности "Велосипед"</param>
/// <param name="mapper">Маппер</param>
[Route("api/[controller]")]
[ApiController]
public class BicycleController(IRepository<Bicycle, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получить все велосипеды
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<BicycleDto>> Get()
    {
        var get = mapper.Map<List<BicycleDto>>(repository.GetList());
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
    public ActionResult<BicycleDto> Get(int id)
    {
        var bicycle = repository.GetItem(id);
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
    public IActionResult Post([FromBody] BicycleDto value)
    {
        var bicycle = mapper.Map<Bicycle>(value);
        repository.AddItem(bicycle);
        return Ok();
    }


    /// <summary>
    /// Обновить велосипед по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] BicycleDto value)
    {
        var bicycle = mapper.Map<Bicycle>(value);

        if (!repository.UpdateItem(id, bicycle))
            return NoContent();

        var bicycleDto = mapper.Map<BicycleDto>(repository.GetItem(id));
        return Ok(bicycleDto);
    }


    /// <summary>
    /// Удалить велосипед по id
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
