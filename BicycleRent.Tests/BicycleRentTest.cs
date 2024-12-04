using BicycleRent.Domain;

namespace BicycleRent.Tests;

public class BicycleRentTest(BicycleRentDataSeeder fixture) : IClassFixture<BicycleRentDataSeeder>
{
    private readonly BicycleRentDataSeeder _fixture = fixture;

    /// <summary>
    /// 1) Вывести информацию обо всех спортивных велосипедах
    /// </summary>
    [Fact]
    public void TestInfoSportBike()
    {
        var _bikes = _fixture.Bicycles;

        var result =
        (
            from bike in _bikes
            where bike.Type.Type == "Sport"
            select bike
        ).ToList();

        Assert.Equal(3, result.Count);
    }


    /// <summary>
    /// 2) Вывести информацию обо всех клиентах, которые брали в аренду горные велосипеды, 
    /// упорядочить по ФИО.
    /// </summary>
    [Fact]
    public void TestInfoClientSport()
    {
        var _rents = _fixture.Rents;
        var _renters = _fixture.Renters;

        var result =
        (
            from rent in _rents
            where rent.Bicycle.Type.Type == "Mountain"
            orderby rent.Renter.FullName
            select rent.Renter
        ).Distinct().ToList();

        Assert.Equal(5, result.Count);
    }


    /// <summary>
    /// 3) Вывести суммарное время аренды велосипедов каждого типа.
    /// </summary>
    [Fact]
    public void TestSumTimeRentForType()
    {
        var _rents = _fixture.Rents;
        var _bikes = _fixture.Bicycles;
        var _bikeTypes = _fixture.BicycleTypes;

        var result =
        (

            from rent in _rents
            group rent by rent.Bicycle.Type into typeRent
            let sum = typeRent.Sum(r => r.TimeRent.TotalHours)
            select new { Hours = sum, BikeType = typeRent.Key.Type }
        ).ToList();

        Assert.Equal(4, result.Count);
    }


    /// <summary>
    /// 4) Вывести информацию о клиентах, бравших велосипеды на прокат больше всего раз.
    /// </summary>
    [Fact]
    public void TestClientsMaxRent()
    {
        var _rents = _fixture.Rents;
        var _renters = _fixture.Renters;

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
        ).ToList();

        Assert.Single(result);
    }


    /// <summary>
    /// 5) Вывести информацию о топ 5 наиболее часто арендуемых велосипедов.
    /// </summary>
    [Fact]
    public void TestTopRentBikes()
    {
        var _rents = _fixture.Rents;
        var _bikes = _fixture.Bicycles;

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
        ).Take(5).ToList();

        Assert.Equal(5, result.Count);
    }


    /// <summary>
    /// 6) Вывести информацию о минимальном, максимальном и 
    /// среднем времени аренды велосипедов.
    /// </summary>
    [Fact]
    public void TestStatisticTimeRent()
    {
        var _rents = _fixture.Rents;

        List<double> expected = [1, 8, 2.6];

        var result =
        (
            from rent in _rents
            select rent.TimeRent.TotalHours
        ).ToList();

        var minRentTime = result.Min();
        var maxRentTime = result.Max();
        var avgRentTime = result.Average();
        for (var i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i], result[i], 1e4);
        }
    }
}