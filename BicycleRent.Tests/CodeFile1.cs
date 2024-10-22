using BicycleRent.Domain;
using BicycleRent.Tests;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using Xunit.Sdk;

int main()
{
    var _fixture = new BicycleRentFixture();

    var _bikes = _fixture.Bicycles;
    var _renters = _fixture.Renters;
    var _rents = _fixture.Rents;
    var _bikeTypes = _fixture.BicycleTypes;
    /*
    var result1 =
    (
        from bike in _bikes
        where bike.Type.Type == "Sport"
        select bike
    ).ToList();

    //foreach (var bike in result1 )
    //{
    //    Console.WriteLine(bike.IdBicycle);
    //    Console.WriteLine(bike.SerialNumber);
    //    Console.WriteLine(bike.Type.Type);
    //    Console.WriteLine(bike.Model);
    //    Console.WriteLine(bike.Color);
    //    Console.WriteLine("-----------------");
    //}


    var result2 = 
    (
        from rent in _rents
        where rent.Bicycle.Type.Type == "Mountain"
        orderby rent.Client.FullName
        select rent.Client
    ).Distinct().ToList();


    //foreach (var client in result2)
    //{
    //    Console.WriteLine( client.IdClient );
    //    Console.WriteLine( client.FullName );
    //    Console.WriteLine( client.BirthDate );
    //    Console.WriteLine( client.PhoneNumber );
    //    Console.WriteLine("-----------------");
    //}

    var result3 =
    (

        from rent in _rents
        join bike in _bikes on rent.Bicycle.IdBicycle equals bike.IdBicycle
        join type in _bikeTypes on bike.Type.IdType equals type.IdType
        let countHours = _rents.Sum(r => { if (r.Bicycle.Type.Type == type.Type) { return r.TimeRent; } else return 0; })
        orderby rent.Bicycle.Type.IdType
        select new { Hours = countHours, BikeType = type.Type }
        ).Distinct().ToList();

    //foreach ( var item in result3 )
    //{
    //    Console.WriteLine( item.Hours);
    //    Console.WriteLine(item.BikeType);
    //    Console.WriteLine("-----------------");
    //}

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

    ).ToList();

    var maxRent = res.Max(r => r.CountRent);

    var result4 =
    (
        from r in res
        where r.CountRent == maxRent
        select r
    ).ToList();

    //foreach ( var item in result4 )
    //{
    //    Console.WriteLine( item.CountRent );
    //    Console.WriteLine(item.ClientRent.IdClient);
    //    Console.WriteLine(item.ClientRent.FullName);
    //    Console.WriteLine(item.ClientRent.BirthDate);
    //    Console.WriteLine(item.ClientRent.PhoneNumber);
    //    Console.WriteLine("-----------------");
    //}

    var result5 =
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

    foreach (var bike in result5)
    {
        Console.WriteLine(bike.CountRent);
        Console.WriteLine(bike.BikeRent.IdBicycle);
        Console.WriteLine(bike.BikeRent.SerialNumber);
        Console.WriteLine(bike.BikeRent.Type.Type);
        Console.WriteLine(bike.BikeRent.Model);
        Console.WriteLine(bike.BikeRent.Color);
        Console.WriteLine("-----------------");
    }

    var result6 =
    (
        from rent in _rents
        select rent.TimeRent
    ).ToList();

    var minRentTime = result6.Min();
    var maxRentTime = result6.Max();
    var avgRentTime = result6.Average();

    //Console.WriteLine(minRentTime);
    //Console.WriteLine(maxRentTime);
    //Console.WriteLine(avgRentTime);
    */

    //var result3 =
    //(
    //    from rent in _rents
    //    join bike in _bikes on rent.Bicycle.PK_IdBicycle equals bike.PK_IdBicycle
    //    join type in _bikeTypes on bike.Type.PK_IdType equals type.PK_IdType
    //    let countHours = _rents.Sum(r => { if (r.Bicycle.Type.Type == type.Type) { return r.TimeRent; } else return 0; })
    //    orderby rent.Bicycle.Type.PK_IdType
    //    select new { Hours = countHours, BikeType = type.Type }
    // ).Distinct().ToList();


    //var res =
    //    from rent in _rents
    //    group rent by rent.Bicycle.Type into typeRent
    //    let sum = typeRent.Sum(r => r.TimeRent)
    //    select new { Hours = sum, BikeType = typeRent.Key.Type };

    //foreach (var r in res)
    //{
    //    Console.WriteLine(r.Hours);
    //    Console.WriteLine(r.BikeType);

    //}

    var res =
    (
        from client in _renters
        let countRent = _rents.Count(r => client.PK_IdRenter == r.Renter.PK_IdRenter)
        orderby countRent descending
        select
        new
        {
            CountRent = countRent,
            ClientRent = client
        }

    ).ToList();

    var maxRent = res.Max(r => r.CountRent);

    var result4 =
    (
        from r in res
        where r.CountRent == maxRent
        select r
    ).ToList();

    foreach (var item in result4)
    {
        Console.WriteLine(item.CountRent);
        Console.WriteLine(item.ClientRent.PK_IdRenter);
        Console.WriteLine(item.ClientRent.FullName);
        Console.WriteLine(item.ClientRent.BirthDate);
        Console.WriteLine(item.ClientRent.PhoneNumber);
        Console.WriteLine("-----------------");
    }
    return 0;
}

main();