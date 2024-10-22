using BicycleRent.Domain;
using System.Globalization;

namespace BicycleRent.Tests;

public class BicycleRentFixture
{
    public List<Bicycle> Bicycles;
    public List<BicycleType> BicycleTypes;
    public List<BicycleRenter> Renters;
    public List<Rent> Rents;

    public BicycleRentFixture()
    {
        BicycleTypes =
        [
            new BicycleType {PK_IdType = 0, Type = "Mountain", Price = 300 },
            new BicycleType { PK_IdType = 1, Type = "Road", Price = 200},
            new BicycleType { PK_IdType = 2, Type = "Walking", Price = 200},
            new BicycleType { PK_IdType = 3, Type = "Sport", Price = 250}
        ];

        Bicycles =
        [
            new Bicycle
            {
                PK_IdBicycle = 0, SerialNumber = "M001", Type = BicycleTypes[0],
                Model = "Navigator 910 MD", Color = "Blue"
            },
            new Bicycle
            {
                PK_IdBicycle = 1, SerialNumber = "M002", Type = BicycleTypes[0],
                Model = "Forward Apache 29 XD", Color = "Orange"
            },
            new Bicycle
            {
                PK_IdBicycle = 2, SerialNumber = "M003", Type = BicycleTypes[0],
                Model = "Stinger Element Evo 29", Color = "Yellow"
            },
            new Bicycle
            {
                PK_IdBicycle = 3, SerialNumber = "R001", Type = BicycleTypes[1],
                Model = "Aspect Allroad", Color = "White"
            },
            new Bicycle
            {
                PK_IdBicycle = 4, SerialNumber = "R002", Type = BicycleTypes[1],
                Model = "Stark Peloton", Color = "Black"
            },
            new Bicycle
            {
                PK_IdBicycle = 5, SerialNumber = "R003", Type = BicycleTypes[1],
                Model = "Format 5211", Color = "Black-Blue"
            },
            new Bicycle
            {
                PK_IdBicycle = 6, SerialNumber = "W001", Type = BicycleTypes[2],
                Model = "Stark Comfort 3-speed", Color = "Beige"
            },
            new Bicycle
            {
                PK_IdBicycle = 7, SerialNumber = "W002", Type = BicycleTypes[2],
                Model = "Stels Energy VI", Color = "Gray"
            },
            new Bicycle
            {
                PK_IdBicycle = 8, SerialNumber = "W003", Type = BicycleTypes[2],
                Model = "Stark Comfort 3-speed", Color = "White"
            },
            new Bicycle
            {
                PK_IdBicycle = 9, SerialNumber = "S001", Type = BicycleTypes[3],
                Model = "Format 5222 CF", Color = "Orange"
            },
            new Bicycle
            {
                PK_IdBicycle = 10, SerialNumber = "S002", Type = BicycleTypes[3],
                Model = "Bear Bike Perm 2021", Color = "Beige"
            },
            new Bicycle
            {
                PK_IdBicycle = 11, SerialNumber = "S003", Type = BicycleTypes[3],
                Model = "Electra Loft 7D", Color = "Black"
            }
        ];

        Renters =
        [
            new BicycleRenter
            {
                PK_IdRenter = 0, FullName = "Kruglova Daria Grigorievna",
                BirthDate = new DateOnly(2000, 9, 1), PhoneNumber = "71110010101"
            },
            new BicycleRenter
            {
                PK_IdRenter = 1, FullName = "Astakhov Timur Fedorovich",
                BirthDate = new DateOnly(1978, 1, 27), PhoneNumber = "71114668965"
            },
            new BicycleRenter
            {
                PK_IdRenter = 2, FullName = "Morozov Konstantin Alexandrovich",
                BirthDate = new DateOnly(1999, 8, 10), PhoneNumber = "71117382789"
            },
            new BicycleRenter
            {
                PK_IdRenter = 3, FullName = "Timofeev Nikolai Alexandrovich",
                BirthDate = new DateOnly(2004, 12, 11), PhoneNumber = "71110661323"
            },
            new BicycleRenter
            {
                PK_IdRenter = 4, FullName = "Zakharova Kristina Konstantinovna",
                BirthDate = new DateOnly(1989, 3, 22), PhoneNumber = "71111970567"
            },
            new BicycleRenter
            {
                PK_IdRenter = 5, FullName = "Shcherbakov Vladimir Semyonovich",
                BirthDate = new DateOnly(2002, 5, 17), PhoneNumber = "71113754455"
            },
            new BicycleRenter
            {
                PK_IdRenter = 6, FullName = "Stepanova Ekaterina Dmitrievna",
                BirthDate = new DateOnly(1997, 10, 19), PhoneNumber = "71111238745"
            },
            new BicycleRenter
            {
                PK_IdRenter = 7, FullName = "Kuznetsova Alina Igorevna",
                BirthDate = new DateOnly(1998, 6, 8), PhoneNumber = "71113039008"
            },
            new BicycleRenter
            {
                PK_IdRenter = 8, FullName = "Sokolov Daniil Ivanovich",
                BirthDate = new DateOnly(2003, 5, 28), PhoneNumber = "71118567832"
            },
            new BicycleRenter
            {
                PK_IdRenter = 9, FullName = "Makarov Savva Evgenievich",
                BirthDate = new DateOnly(2000, 2, 28), PhoneNumber = "71113840393"
            }
        ];

        Rents =
        [
            new Rent
            {
                PK_IdRent = 0, Renter = Renters[0], Bicycle = Bicycles[0],
                TimeStart = new TimeOnly(12, 35), TimeEnd = new TimeOnly(14, 35), TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 1, Renter = Renters[1], Bicycle = Bicycles[1],
                TimeStart = new TimeOnly(16, 50), TimeEnd = new TimeOnly(20, 50),TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 2, Renter = Renters[1], Bicycle = Bicycles[1],
                TimeStart = new TimeOnly(9, 0), TimeEnd = new TimeOnly(17, 0), TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 3, Renter = Renters[1], Bicycle = Bicycles[10],
                TimeStart = new TimeOnly(15, 15), TimeEnd = new TimeOnly(18, 15), TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 4, Renter = Renters[2], Bicycle = Bicycles[11],
                TimeStart = new TimeOnly(9, 0), TimeEnd = new TimeOnly(17, 0), TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 5, Renter = Renters[3], Bicycle = Bicycles[7],
                TimeStart = new TimeOnly(17, 30), TimeEnd = new TimeOnly(18, 30), TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 6, Renter = Renters[3], Bicycle = Bicycles[8],
                TimeStart = new TimeOnly(18, 20), TimeEnd = new TimeOnly(20, 20), TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 7, Renter = Renters[4], Bicycle = Bicycles[3],
                TimeStart = new TimeOnly(13, 55), TimeEnd = new TimeOnly(16, 55), TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 8, Renter = Renters[5], Bicycle = Bicycles[2],
                TimeStart = new TimeOnly(7, 45), TimeEnd = new TimeOnly(10, 45), TimeRent = 0
            },
            new()
            {
                PK_IdRent = 9, Renter = Renters[5], Bicycle = Bicycles[7],
                TimeStart = new TimeOnly(19, 35), TimeEnd = new TimeOnly(20, 35), TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 10, Renter = Renters[5], Bicycle = Bicycles[6],
                TimeStart = new TimeOnly(14, 0), TimeEnd = new TimeOnly(15, 0), TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 11, Renter = Renters[5], Bicycle = Bicycles[5],
                TimeStart = new TimeOnly(13, 40), TimeEnd = new TimeOnly(17, 40), TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 12, Renter = Renters[6], Bicycle = Bicycles[2],
                TimeStart = new TimeOnly(10, 0), TimeEnd = new TimeOnly(11, 0), TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 13, Renter = Renters[7], Bicycle = Bicycles[4],
                TimeStart = new TimeOnly(12, 05), TimeEnd = new TimeOnly(14, 05), TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 14, Renter = Renters[7], Bicycle = Bicycles[9],
                TimeStart = new TimeOnly(12, 0), TimeEnd = new TimeOnly(13, 0), TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 15, Renter = Renters[8], Bicycle = Bicycles[6],
                TimeStart = new TimeOnly(16, 30), TimeEnd = new TimeOnly(18, 30), TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 16, Renter = Renters[8], Bicycle = Bicycles[10],
                TimeStart = new TimeOnly(17, 45), TimeEnd = new TimeOnly(18, 45), TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 17, Renter = Renters[8], Bicycle = Bicycles[0],
                TimeStart = new TimeOnly(10, 0), TimeEnd = new TimeOnly(13, 0), TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 18, Renter = Renters[9], Bicycle = Bicycles[11],
                TimeStart = new TimeOnly(17, 45), TimeEnd = new TimeOnly(18, 45), TimeRent = 0
            },
            new Rent
            {
                PK_IdRent = 19, Renter = Renters[9], Bicycle = Bicycles[7],
                TimeStart = new TimeOnly(16, 0), TimeEnd = new TimeOnly(17, 0), TimeRent = 0
            }
        ];

        foreach (var rent in Rents)
            rent.TimeRent = (rent.TimeEnd - rent.TimeStart).Hours;
    }
}
