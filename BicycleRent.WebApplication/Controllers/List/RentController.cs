using AutoMapper;
using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Servicies.Dto;
using Microsoft.AspNetCore.Mvc;


namespace BicycleRent.WebApplication.Controllers.List;

/// <summary>
/// Класс-контроллер для сущности "Аренда велосипеда"
/// </summary>
/// <param name="repository"></param>
/// <param name="mapper"></param>
[Route("api/[controller]")]
[ApiController]
public class RentController(IRepository<Rent, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Получить все арендны велосипедов
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<RentDto>> Get()
    {
        var get = mapper.Map<List<RentDto>>(repository.GetList());
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
    public ActionResult<Rent> Get(int id)
    {
        var rent = repository.GetItem(id);

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
    public IActionResult Post([FromBody] RentDto value)
    {
        var rent = mapper.Map<Rent>(value);
        repository.AddItem(rent);
        return Ok();
    }


    /// <summary>
    /// Обновить аренду велосипеда по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] RentDto value)
    {
        var rent = mapper.Map<Rent>(value);

        if (!repository.UpdateItem(id, rent))
            return NoContent();

        var rentDto = mapper.Map<RentDto>(repository.GetItem(id));

        return Ok(rentDto);
    }


    /// <summary>
    /// Удалить аренду велосипеда по id
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
