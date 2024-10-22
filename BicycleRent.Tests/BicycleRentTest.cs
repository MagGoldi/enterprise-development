using BicycleRent.Domain;

namespace BicycleRent.Tests;

public class BicycleRentTest(BicycleRentFixture fixture): IClassFixture<BicycleRentFixture>
{
    private readonly BicycleRentFixture _fixture = fixture;

    /// <summary>
    /// 1) Вывести информацию обо всех спортивных велосипедах
    /// </summary>
    [Fact]
    public void TestInfoSportBike()
    {
        var _bikes = _fixture.Bicycles;
        var expected = new List<Bicycle> { _bikes[9], _bikes[10], _bikes[11] };

        var result =
        (
            from bike in _bikes
            where bike.Type.Type == "Sport"
            select bike
        ).ToList();

        Assert.True(result.Count == 3);
        Assert.Equal(expected, result);
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

        var expected = new List<BicycleRenter>
        {
            _renters[1], _renters[0], _renters[5], _renters[8], _renters[6]
        };

        var result =
        (
            from rent in _rents
            where rent.Bicycle.Type.Type == "Mountain"
            orderby rent.Renter.FullName
            select rent.Renter
        ).Distinct().ToList();

        Assert.True(result.Count == 5);
        Assert.Equal(expected, result);
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

        var expected = new[]
        {
            new {Hours = 21, BikeType = "Mountain"},
            new {Hours = 14, BikeType = "Sport"},
            new {Hours = 8, BikeType = "Walking"},
            new {Hours = 9, BikeType = "Road"}
        };

        var result =
        (

            from rent in _rents
            group rent by rent.Bicycle.Type into typeRent
            let sum = typeRent.Sum(r => r.TimeRent)
            select new { Hours = sum, BikeType = typeRent.Key.Type }
        ).ToList();

        Assert.True(result.Count == 4);
        Assert.Equal(expected, result);
    }


    /// <summary>
    /// 4) Вывести информацию о клиентах, бравших велосипеды на прокат больше всего раз.
    /// </summary>
    [Fact]
    public void TestClientsMaxRent()
    {
        var _rents = _fixture.Rents;
        var _renters = _fixture.Renters;

        var expected = new[] { new { CountRent = 4, Renter = _renters[5] } };


        var res =
        (
            from renter in _renters
            let countRent = _rents.Count(r => renter.PK_IdRenter == r.Renter.PK_IdRenter)
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

        Assert.True(result.Count == 1);
        Assert.Equal(expected, result);
    }


    /// <summary>
    /// 5) Вывести информацию о топ 5 наиболее часто арендуемых велосипедов.
    /// </summary>
    [Fact]
    public void TestTopRentBikes()
    {
        var _rents = _fixture.Rents;
        var _bikes = _fixture.Bicycles;

        var expected = new[]
        {
            new {CountRent = 3, BikeRent = _bikes[7]},
            new {CountRent = 2, BikeRent = _bikes[0]},
            new {CountRent = 2, BikeRent = _bikes[1]},
            new {CountRent = 2, BikeRent = _bikes[2]},
            new {CountRent = 2, BikeRent = _bikes[6]}
        };

        var result =
        (
            from bike in _bikes
            let countRent = _rents.Count(r => bike.PK_IdBicycle == r.Bicycle.PK_IdBicycle)
            orderby countRent descending
            select
            new
            {
                CountRent = countRent,
                BikeRent = bike
            }
        ).Take(5).ToList();

        Assert.True(result.Count == 5);
        Assert.Equal(expected, result);
    }


    /// <summary>
    /// 6) ������� ���������� � �����������, ������������ � 
    /// ������� ������� ������ �����������.
    /// </summary>
    [Fact]
    public void TestStatisticTimeRent()
    {
        var _rents = _fixture.Rents;

        List<double> expected = [1, 8, 2.6];

        var result =
        (
            from rent in _rents
            select rent.TimeRent
        ).ToList();

        var minRentTime = result.Min();
        var maxRentTime = result.Max();
        var avgRentTime = result.Average();

        for ( var i = 0; i < expected.Count; i++ )
        {
            Assert.Equal(expected[i], result[i], 1e4);
        }
    }
}