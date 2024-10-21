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

        Assert.True(result.Count != 0);
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
        var _clients = _fixture.Clients;

        var expected = new List<Client>
        {
            _clients[1], _clients[0], _clients[5], _clients[8], _clients[6]
        };

        var result =
        (
            from rent in _rents
            where rent.Bicycle.Type.Type == "Mountain"
            orderby rent.Client.FullName
            select rent.Client
        ).Distinct().ToList();

        Assert.True(result.Count != 0);
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
            new {Hours = 9, BikeType = "Road"},
            new {Hours = 8, BikeType = "Walking"},
            new {Hours = 14, BikeType = "Sport"}
        };

        var result =
        (

            from rent in _rents
            join bike in _bikes on rent.Bicycle.IdBicycle equals bike.IdBicycle
            join type in _bikeTypes on bike.Type.IdType equals type.IdType
            let countHours = _rents.Sum(r => { if (r.Bicycle.Type.Type == type.Type) { return r.TimeRent; } else return 0; })
            orderby rent.Bicycle.Type.IdType
            select new { Hours = countHours, BikeType = type.Type }
        ).Distinct().ToList();

        Assert.True(result.Count != 0);
        Assert.Equal(expected, result);
    }


    /// <summary>
    /// 4) Вывести информацию о клиентах, бравших велосипеды на прокат больше всего раз.
    /// </summary>
    [Fact]
    public void TestClientsMaxRent()
    {
        var _rents = _fixture.Rents;
        var _clients = _fixture.Clients;

        var expected = new[] { new { CountRent = 4, ClientRent = _clients[5] } };


        var res =
        (
            from client in _clients
            let countRent = _rents.Count(r => client.IdClient == r.Client.IdClient)
            orderby countRent descending
            select
            new
            {
                CountRent = countRent,
                ClientRent = client
            }
        ).Take(5).ToList();

        var maxRent = res.Max(r => r.CountRent);

        var result =
        (
            from r in res
            where r.CountRent == maxRent
            select r
        ).ToList();

        Assert.True(result.Count != 0);
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
            let countRent = _rents.Count(r => bike.IdBicycle == r.Bicycle.IdBicycle)
            orderby countRent descending
            select
            new
            {
                CountRent = countRent,
                BikeRent = bike
            }
        ).Take(5).ToList();

        Assert.True(result.Count != 0);
        Assert.Equal(expected, result);
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
            select rent.TimeRent
        ).ToList();

        var minRentTime = result.Min();
        var maxRentTime = result.Max();
        var avgRentTime = result.Average();

        Assert.True(result.Count != 0);
        for ( var i = 0; i < expected.Count; i++ )
        {
            Assert.Equal(expected[i], result[i], 1e4);
        }
    }
}