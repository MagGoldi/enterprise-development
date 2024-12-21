using AutoMapper;
using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Servicies.Dto;
using Microsoft.AspNetCore.Mvc;


namespace BicycleRent.WebApplication.Controllers.DataBase;

/// <summary>
/// Класс-контроллер для сущности "Аренда велосипеда"
/// </summary>
/// <param name="repository"></param>
/// <param name="mapper"></param>
[Route("api/[controller]")]
[ApiController]
public class RentDbController(IRepositoryDb<Rent, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получить все арендны велосипедов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RentDto>>> Get()
    {
        var repo = await repository.GetList();
        repo =
        (
            from r in repo orderby r.RentId select r
        ).ToList();
        var get = mapper.Map<List<RentDto>>(repo);
        if (get.Count == 0)
            return NoContent();
        return Ok(get);
    }


    /// <summary>
    /// Получить аренду велосипеда по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<RentDto>> Get(int id)
    {
        var rent = await repository.GetItem(id);

        if (rent == null)
            return NoContent();
        var rentDto = mapper.Map<RentDto>(rent);

        return Ok(rentDto);
    }


    /// <summary>
    /// Добавить аренду велосипеда
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RentDto value)
    {
        var rent = mapper.Map<Rent>(value);
        await repository.AddItem(rent);
        return Ok();
    }


    /// <summary>
    /// Обновить аренду велосипеда по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] RentDto value)
    {
        var rent = mapper.Map<Rent>(value);
        var update = await repository.UpdateItem(id, rent);

        if (!update)
            return NoContent();
        
        var rentUpdate = repository.GetItem(id);
        var rentDto = mapper.Map<RentDto>(rentUpdate);

        return Ok(rentDto);
    }


    /// <summary>
    /// Удалить аренду велосипеда по id
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
