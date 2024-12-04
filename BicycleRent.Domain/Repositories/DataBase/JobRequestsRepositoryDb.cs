using BicycleRent.Domain.Entities;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Domain.JobRequestsTypes;
namespace BicycleRent.Domain.Repositories.Database;

public class JobRequestsRepositoryDb(
    IRepositoryDb<BicycleType, int> typeRepository,
    IRepositoryDb<Bicycle, int> bicycleRepository,
    IRepositoryDb<BicycleRenter, int> renterRepository,
    IRepositoryDb<Rent, int> rentRepository
    ) : IRepositoryRequestsDb
{

    public async Task<List<Bicycle>> GetInfoSportBike()
    {
        var _bikes = await bicycleRepository.GetList();

        var result =
        (
            from bike in _bikes
            where bike.Type.Type == "Sport"
            select bike
        ).ToList();

        return result;
    }


    public async Task<List<BicycleRenter>> GetInfoClientMountain()
    {
        var _rents = await rentRepository.GetList();
        var _renters = renterRepository.GetList();

        var result =
        (
            from rent in _rents
            where rent.Bicycle.Type.Type == "Mountain"
            orderby rent.Renter.FullName
            select rent.Renter
        ).Distinct().ToList();

        return result;
    }


    public async Task<List<NumberAndEntity<double, BicycleType>>> GetSumTimeRentForType()
    {
        var _rents = await rentRepository.GetList();
        var _bikes = await bicycleRepository.GetList();
        var _bikeTypes = await typeRepository.GetList();

        var result =
        (

            from rent in _rents
            group rent by rent.Bicycle.Type into typeRent
            let sum = typeRent.Sum(r => r.TimeRent.TotalHours)
            select new { Hours = sum, BikeType = typeRent.Key }
        ).Select(res => new NumberAndEntity<double, BicycleType> { Count = res.Hours, EntityRent = res.BikeType }).ToList();

        return result;
    }


    public async Task<List<NumberAndEntity<int, BicycleRenter>>> GetClientsMaxRent()
    {
        var _rents = await rentRepository.GetList();
        var _renters = await renterRepository.GetList();

        var res =
        (
            from renter in _renters
            let countRent = _rents.Count(r => renter.RenterId == r.Renter.RenterId)
            orderby countRent descending
            select
            new
            {
                CountRent = countRent,
                Renter = renter
            }
        ).ToList();

        var maxRent = res.Max(r => r.CountRent);

        var result =
        (
            from r in res
            where r.CountRent == maxRent
            select r
        ).Select(res => new NumberAndEntity<int, BicycleRenter> { Count = res.CountRent, EntityRent = res.Renter }).ToList();

        return result;
    }


    public async Task<List<NumberAndEntity<int, Bicycle>>> GetTopRentBikes()
    {
        var _rents = await rentRepository.GetList();
        var _bikes = await bicycleRepository.GetList();

        var result =
        (
            from bike in _bikes
            let countRent = _rents.Count(r => bike.BicycleId == r.Bicycle.BicycleId)
            orderby countRent descending
            select
            new
            {
                CountRent = countRent,
                BikeRent = bike
            }
        ).Take(5).Select(res => new NumberAndEntity<int, Bicycle> { Count = res.CountRent, EntityRent = res.BikeRent }).ToList();

        return result;
    }


    public async Task<List<double>> GetStatisticTimeRent()
    {
        var _rents = await rentRepository.GetList();

        List<double> expected = [1, 8, 2.6];

        var result =
        (
            from rent in _rents
            select rent.TimeRent.TotalHours
        ).ToList();

        var minRentTime = result.Min();
        var maxRentTime = result.Max();
        var avgRentTime = result.Average();

        return new List<double> { minRentTime, maxRentTime, avgRentTime };
    }
}
