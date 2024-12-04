using AutoMapper;
using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Servicies.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRent.WebApplication.Controllers.List;

/// <summary>
/// Класс-контроллер для сущности "Арендатор велосипеда"
/// </summary>
/// <param name="repository"></param>
/// <param name="mapper"></param>
[Route("api/[controller]")]
[ApiController]
public class BicycleRenterController(IRepository<BicycleRenter, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получить всех арендаторов велосипедов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<BicycleRenterDto>> Get()
    {
        var get = mapper.Map<List<BicycleRenterDto>>(repository.GetList());
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
    public ActionResult<BicycleRenterDto> Get(int id)
    {
        var renter = repository.GetItem(id);

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
    public IActionResult Post([FromBody] BicycleRenterDto value)
    {
        var renter = mapper.Map<BicycleRenter>(value);
        repository.AddItem(renter);
        return Ok();
    }


    /// <summary>
    /// Обновить арендатора велосипеда по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] BicycleRenterDto value)
    {
        var renter = mapper.Map<BicycleRenter>(value);

        if (!repository.UpdateItem(id, renter))
            return NoContent();

        var renterDto = mapper.Map<BicycleRenterDto>(repository.GetItem(id));
        return Ok(renterDto);
    }


    /// <summary>
    /// Удалить арендатора велосипеда по id
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
