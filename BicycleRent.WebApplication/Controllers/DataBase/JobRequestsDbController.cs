using AutoMapper;
using BicycleRent.Domain.Entities;
using BicycleRent.Domain.JobRequestsTypes;
using BicycleRent.Domain.Repositories.Database;
using BicycleRent.Servicies.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRent.WebApplication.Controllers.DataBase;

/// <summary>
/// Класс-контроллер для выполнения запросов
/// </summary>
/// <param name="repository">Репозиторий для запросов</param>
/// <param name="mapper">Маппер</param>
[Route("api/[controller]")]
[ApiController]
public class JobRequestsDbController(JobRequestsRepositoryDb repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// 1) Вывести информацию обо всех спортивных велосипедах
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetInfoSportBike")]
    public async Task<ActionResult<IEnumerable<BicycleDto>>> GetInfoSportBike()
    {
        var repo = await repository.GetInfoSportBike();
        var get = mapper.Map<List<BicycleDto>>(repo);
        if (get.Count == 0)
            return NoContent();
        return Ok(get);
    }


    /// <summary>
    /// 2) Вывести информацию обо всех клиентах, которые брали в аренду горные велосипеды, 
    /// упорядочить по ФИО.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetInfoClientMountain")]
    public async Task<ActionResult<IEnumerable<BicycleRenterDto>>> GetInfoClientMountain()
    {
        var repo = await repository.GetInfoClientMountain();
        var get = mapper.Map<List<BicycleRenterDto>>(repo);
        if (get.Count == 0)
            return NoContent();
        return Ok(get);
    }

    /// <summary>
    /// 3) Вывести суммарное время аренды велосипедов каждого типа.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetSumTimeRentForType")]
    public async Task<ActionResult<IEnumerable<NumberAndEntity<double, BicycleTypeDto>>>> GetSumTimeRentForType()
    {
        var repo = await repository.GetSumTimeRentForType();
        var get = (
            from item in repo
            select new NumberAndEntity<double, BicycleTypeDto> { Count = item.Count, EntityRent = mapper.Map<BicycleTypeDto>(item.EntityRent) }
            ).ToList();

        if (get.Count == 0)
            return NoContent();
        return Ok(get);
    }

    /// <summary>
    /// 4) Вывести информацию о клиентах, бравших велосипеды на прокат больше всего раз.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetClientsMaxRent")]
    public async Task<ActionResult<IEnumerable<NumberAndEntity<int, BicycleRenterDto>>>> GetClientsMaxRent()
    {
        var repo = await repository.GetClientsMaxRent();
        var get = (
            from item in repo
            select new NumberAndEntity<double, BicycleRenterDto> { Count = item.Count, EntityRent = mapper.Map<BicycleRenterDto>(item.EntityRent) }
            ).ToList();

        if (get.Count == 0)
            return NoContent();
        return Ok(get);
    }


    /// <summary>
    /// 5) Вывести информацию о топ 5 наиболее часто арендуемых велосипедов.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetTopRentBikes")]
    public async Task<ActionResult<IEnumerable<NumberAndEntity<int, BicycleDto>>>> GetTopRentBikes()
    {
        var repo = await repository.GetTopRentBikes();
        var get = (
            from item in repo
            select new NumberAndEntity<double, BicycleDto> { Count = item.Count, EntityRent = mapper.Map<BicycleDto>(item.EntityRent) }
            ).ToList();

        if (get.Count == 0)
            return NoContent();
        return Ok(get);
    }


    /// <summary>
    /// 6) Вывести информацию о минимальном, максимальном и 
    /// среднем времени аренды велосипедов.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetStatisticTimeRent")]
    public async Task<ActionResult<IEnumerable<double>>> GetStatisticTimeRent()
    {
        var repo = await repository.GetStatisticTimeRent();
        return Ok(repo);
    }
}
