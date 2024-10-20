namespace BicycleRent.Tests;

public class BicycleRentTest(BicycleRentFixture fixture): IClassFixture<BicycleRentFixture>
{
    private readonly BicycleRentFixture _fixture = fixture;

    /// <summary>
    /// 1) Вывести информацию обо всех спортивных велосипедах
    /// </summary>
    //[Fact]
    public void TestInfoSportBike()
    {
        var _bikes = _fixture.Bicycles;

        var result =
        (
            from bike in _bikes
            where bike.Type.Type == "Sport"
            select bike
        ).ToList();
    }
}