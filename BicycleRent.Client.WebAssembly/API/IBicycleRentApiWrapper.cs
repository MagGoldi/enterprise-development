namespace BicycleRent.Client.WebAssembly.API;

public interface IBicycleRentApiWrapper
{
    Task CreateBicycle(BicycleDto newBicycle);
    Task CreateBicycleType(BicycleTypeDto newType);
    Task CreateBicycleRenter(BicycleRenterDto newRenter);
    Task CreateRent(RentDto newRent);

    Task UpdateBicycle(int id, BicycleDto newBicycle);
    Task UpdateBicycleType(int id, BicycleTypeDto newType);
    Task UpdateBicycleRenter(int id, BicycleRenterDto newRenter);
    Task UpdateRent(int id, RentDto newRent);


    Task DeleteBicycle(int id);
    Task DeleteBicycleType(int id);
    Task DeleteBicycleRenter(int id);
    Task DeleteRent(int id);

    Task<BicycleDto> GetBicycle(int id);
    Task<BicycleTypeDto> GetBicycleType(int id);
    Task<BicycleRenterDto> GetBicycleRenter(int id);
    Task<RentDto> GetRent(int id);


    Task<ICollection<BicycleDto>> GetAllBicycles();
    Task<ICollection<BicycleTypeDto>> GetAllBicycleTypes();
    Task<ICollection<BicycleRenterDto>> GetAllBicycleRenters();
    Task<ICollection<RentDto>> GetAllRents();


    Task<ICollection<BicycleDto>> InfoSportBike();
    Task<ICollection<BicycleRenterDto>> InfoClientMountain();
    Task<ICollection<DoubleBicycleTypeDtoNumberAndEntity>> SumTimeRentForType();
    Task<ICollection<Int32BicycleRenterDtoNumberAndEntity>> ClientsMaxRent();
    Task<ICollection<Int32BicycleDtoNumberAndEntity>> TopRentBikes();
    Task<ICollection<double>> StatisticTimeRent();
}
