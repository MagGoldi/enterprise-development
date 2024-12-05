using AutoMapper;
using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Servicies.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRent.WebApplication.Controllers.DataBase;

/// <summary>
/// Класс-контроллер для сущности "Арендатор велосипеда"
/// </summary>
/// <param name="repository"></param>
/// <param name="mapper"></param>
[Route("api/[controller]")]
[ApiController]
public class BicycleRenterDbController(IRepositoryDb<BicycleRenter, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получить всех арендаторов велосипедов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BicycleRenterDto>>> Get()
    {
        var repo = await repository.GetList();

        var get = mapper.Map<List<BicycleRenterDto>>(repo);
        if (get.Count == 0)
            return NoContent();
        return Ok(get);
    }


    /// <summary>
    /// Получить арендатора велосипеда по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<BicycleRenterDto>> Get(int id)
    {
        var renter = await repository.GetItem(id);

        if (renter == null)
            return NoContent();

        var renterDto = mapper.Map<BicycleRenterDto>(renter);

        return Ok(renterDto);
    }


    /// <summary>
    /// Добавить арендатора велосипеда
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BicycleRenterDto value)
    {
        var renter = mapper.Map<BicycleRenter>(value);
        await repository.AddItem(renter);
        return Ok();
    }


    /// <summary>
    /// Обновить арендатора велосипеда по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] BicycleRenterDto value)
    {
        var renter = mapper.Map<BicycleRenter>(value);
        var update = await repository.UpdateItem(id, renter);


        if (!update)
            return NoContent();

        var renterUpdate = repository.GetItem(id);
        var renterDto = mapper.Map<BicycleRenterDto>(renterUpdate);
        
        return Ok(renterDto);
    }


    /// <summary>
    /// Удалить арендатора велосипеда по id
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
