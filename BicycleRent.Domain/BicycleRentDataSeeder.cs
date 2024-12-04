using BicycleRent.Domain.Entities;
using System.Security.Cryptography;

namespace BicycleRent.Domain;

public class BicycleRentDataSeeder
{
    public List<Bicycle> Bicycles;
    public List<BicycleType> BicycleTypes;
    public List<BicycleRenter> Renters;
    public List<Rent> Rents;

    public BicycleRentDataSeeder()
    {
        BicycleTypes =
        [
            new BicycleType {TypeId = 1, Type = "Mountain", Price = 300 },
            new BicycleType { TypeId = 2, Type = "Road", Price = 200},
            new BicycleType { TypeId = 3, Type = "Walking", Price = 200},
            new BicycleType { TypeId = 4, Type = "Sport", Price = 250}
        ];

        Bicycles =
        [
            new Bicycle
            {
                BicycleId = 1, SerialNumber = "M001", Type = BicycleTypes[0],
                Model = "Navigator 910 MD", Color = "Blue"
            },
            new Bicycle
            {
                BicycleId = 2, SerialNumber = "M002", Type = BicycleTypes[0],
                Model = "Forward Apache 29 XD", Color = "Orange"
            },
            new Bicycle
            {
                BicycleId = 3, SerialNumber = "M003", Type = BicycleTypes[0],
                Model = "Stinger Element Evo 29", Color = "Yellow"
            },
            new Bicycle
            {
                BicycleId = 4, SerialNumber = "R001", Type = BicycleTypes[1],
                Model = "Aspect Allroad", Color = "White"
            },
            new Bicycle
            {
                BicycleId = 5, SerialNumber = "R002", Type = BicycleTypes[1],
                Model = "Stark Peloton", Color = "Black"
            },
            new Bicycle
            {
                BicycleId = 6, SerialNumber = "R003", Type = BicycleTypes[1],
                Model = "Format 5211", Color = "Black-Blue"
            },
            new Bicycle
            {
                BicycleId = 7, SerialNumber = "W001", Type = BicycleTypes[2],
                Model = "Stark Comfort 3-speed", Color = "Beige"
            },
            new Bicycle
            {
                BicycleId = 8, SerialNumber = "W002", Type = BicycleTypes[2],
                Model = "Stels Energy VI", Color = "Gray"
            },
            new Bicycle
            {
                BicycleId = 9, SerialNumber = "W003", Type = BicycleTypes[2],
                Model = "Stark Comfort 3-speed", Color = "White"
            },
            new Bicycle
            {
                BicycleId = 10, SerialNumber = "S001", Type = BicycleTypes[3],
                Model = "Format 5222 CF", Color = "Orange"
            },
            new Bicycle
            {
                BicycleId = 11, SerialNumber = "S002", Type = BicycleTypes[3],
                Model = "Bear Bike Perm 2021", Color = "Beige"
            },
            new Bicycle
            {
                BicycleId = 12, SerialNumber = "S003", Type = BicycleTypes[3],
                Model = "Electra Loft 7D", Color = "Black"
            }
        ];

        for ( var i = 0; i < Bicycles.Count; i++ )
        {
            Bicycles[i].TypeId = Bicycles[i].Type.TypeId;
        }

        Renters =
        [
            new BicycleRenter
            {
                RenterId = 1, FullName = "Kruglova Daria Grigorievna",
                BirthDate = new DateOnly(2000, 9, 1), PhoneNumber = "71110010101"
            },
            new BicycleRenter
            {
                RenterId = 2, FullName = "Astakhov Timur Fedorovich",
                BirthDate = new DateOnly(1978, 1, 27), PhoneNumber = "71114668965"
            },
            new BicycleRenter
            {
                RenterId = 3, FullName = "Morozov Konstantin Alexandrovich",
                BirthDate = new DateOnly(1999, 8, 10), PhoneNumber = "71117382789"
            },
            new BicycleRenter
            {
                RenterId = 4, FullName = "Timofeev Nikolai Alexandrovich",
                BirthDate = new DateOnly(2004, 12, 11), PhoneNumber = "71110661323"
            },
            new BicycleRenter
            {
                RenterId = 5, FullName = "Zakharova Kristina Konstantinovna",
                BirthDate = new DateOnly(1989, 3, 22), PhoneNumber = "71111970567"
            },
            new BicycleRenter
            {
                RenterId = 6, FullName = "Shcherbakov Vladimir Semyonovich",
                BirthDate = new DateOnly(2002, 5, 17), PhoneNumber = "71113754455"
            },
            new BicycleRenter
            {
                RenterId = 7, FullName = "Stepanova Ekaterina Dmitrievna",
                BirthDate = new DateOnly(1997, 10, 19), PhoneNumber = "71111238745"
            },
            new BicycleRenter
            {
                RenterId = 8, FullName = "Kuznetsova Alina Igorevna",
                BirthDate = new DateOnly(1998, 6, 8), PhoneNumber = "71113039008"
            },
            new BicycleRenter
            {
                RenterId = 9, FullName = "Sokolov Daniil Ivanovich",
                BirthDate = new DateOnly(2003, 5, 28), PhoneNumber = "71118567832"
            },
            new BicycleRenter
            {
                RenterId = 10, FullName = "Makarov Savva Evgenievich",
                BirthDate = new DateOnly(2000, 2, 28), PhoneNumber = "71113840393"
            }
        ];

        Rents =
        [
            new Rent
            {
                RentId = 1, Renter = Renters[0], Bicycle = Bicycles[0],
                TimeStart = new DateTime(2024, 5, 12, 12, 35, 0), TimeEnd = new DateTime(2024, 5, 12, 14, 35, 0)
            },
            new Rent
            {
                RentId = 2, Renter = Renters[1], Bicycle = Bicycles[1],
                TimeStart = new DateTime(2024, 6, 1, 16, 50, 0), TimeEnd = new DateTime(2024, 6, 1, 20, 50, 0)
            },
            new Rent
            {
                RentId = 3, Renter = Renters[1], Bicycle = Bicycles[1],
                TimeStart = new DateTime(2024, 6, 5, 9, 0, 0), TimeEnd = new DateTime(2024, 6, 5, 17, 0, 0)
            },
            new Rent
            {
                RentId = 4, Renter = Renters[1], Bicycle = Bicycles[10],
                TimeStart = new DateTime(2024, 7, 10, 15, 15, 0), TimeEnd = new DateTime(2024, 7, 10, 18, 15, 0)
            },
            new Rent
            {
                RentId = 5, Renter = Renters[2], Bicycle = Bicycles[11],
                TimeStart = new DateTime(2024, 9, 10, 9, 0, 0), TimeEnd = new DateTime(2024, 9, 10, 17, 0, 0)
            },
            new Rent
            {
                RentId = 6, Renter = Renters[3], Bicycle = Bicycles[7],
                TimeStart = new DateTime(2024, 8, 18, 17, 30, 0), TimeEnd = new DateTime(2024, 8, 18, 18, 30, 0)
            },
            new Rent
            {
                RentId = 7, Renter = Renters[3], Bicycle = Bicycles[8],
                TimeStart = new DateTime(2024, 7, 1, 18, 20, 0), TimeEnd = new DateTime(2024, 7, 1, 20, 20, 0)
            },
            new Rent
            {
                RentId = 8, Renter = Renters[4], Bicycle = Bicycles[3],
                TimeStart = new DateTime(2024, 4, 29, 13, 55, 0), TimeEnd = new DateTime(2024, 4, 29, 16, 55, 0)
            },
            new Rent
            {
                RentId = 9, Renter = Renters[5], Bicycle = Bicycles[2],
                TimeStart = new DateTime(2024, 4, 29, 7, 45, 0), TimeEnd = new DateTime(2024, 4, 29, 10, 45, 0)
            },
            new()
            {
                RentId = 10, Renter = Renters[5], Bicycle = Bicycles[7],
                TimeStart = new DateTime(2024, 7, 7, 19, 35, 0), TimeEnd = new DateTime(2024, 7, 7, 20, 35, 0)
            },
            new Rent
            {
                RentId = 11, Renter = Renters[5], Bicycle = Bicycles[6],
                TimeStart = new DateTime(2024, 6, 28, 14, 0, 0), TimeEnd = new DateTime(2024, 6, 28, 15, 0, 0)
            },
            new Rent
            {
                RentId = 12, Renter = Renters[5], Bicycle = Bicycles[5],
                TimeStart = new DateTime(2024, 5, 30, 13, 40, 0), TimeEnd = new DateTime(2024, 5, 30, 17, 40, 0)
            },
            new Rent
            {
                RentId = 13, Renter = Renters[6], Bicycle = Bicycles[2],
                TimeStart = new DateTime(2024, 5, 15, 10, 0, 0), TimeEnd = new DateTime(2024, 5, 15, 11, 0, 0)
            },
            new Rent
            {
                RentId = 14, Renter = Renters[7], Bicycle = Bicycles[4],
                TimeStart = new DateTime(2024, 8, 1, 12, 05, 0), TimeEnd = new DateTime(2024, 8, 1, 14, 05, 0)
            },
            new Rent
            {
                RentId = 15, Renter = Renters[7], Bicycle = Bicycles[9],
                TimeStart = new DateTime(2024, 8, 8, 12, 0, 0), TimeEnd = new DateTime(2024, 8, 8, 13, 0, 0)
            },
            new Rent
            {
                RentId = 16, Renter = Renters[8], Bicycle = Bicycles[6],
                TimeStart = new DateTime(2024, 9, 1, 16, 30, 0), TimeEnd = new DateTime(2024, 9, 1, 18, 30, 0)
            },
            new Rent
            {
                RentId = 17, Renter = Renters[8], Bicycle = Bicycles[10],
                TimeStart = new DateTime(2024, 6, 11, 17, 45, 0), TimeEnd = new DateTime(2024, 6, 11, 18, 45, 0)
            },
            new Rent
            {
                RentId = 18, Renter = Renters[8], Bicycle = Bicycles[0],
                TimeStart = new DateTime(2024, 7, 19, 10, 0, 0), TimeEnd = new DateTime(2024, 7, 19, 13, 0, 0)
            },
            new Rent
            {
                RentId = 19, Renter = Renters[9], Bicycle = Bicycles[11],
                TimeStart = new DateTime(2024, 6, 11, 17, 45, 0), TimeEnd = new DateTime(2024, 6, 11, 18, 45, 0)
            },
            new Rent
            {
                RentId = 20, Renter = Renters[9], Bicycle = Bicycles[7],
                TimeStart = new DateTime(2024, 8, 3, 16, 0, 0), TimeEnd = new DateTime(2024, 8, 3, 17, 0, 0)
            }
        ];

        for (var i = 0; i < Rents.Count; i++)
        {
            Rents[i].RenterId = Rents[i].Renter.RenterId;
            Rents[i].BicycleId = Rents[i].Bicycle.BicycleId;
        }
    }
}
