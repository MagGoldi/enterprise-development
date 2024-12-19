namespace BicycleRent.Client.WebAssembly.API;

public class BicycleRentApiWrapper(IConfiguration configuration): IBicycleRentApiWrapper
{
    public readonly swaggerClient _client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    public async Task CreateBicycle(BicycleDto newBicycle) => await _client.BicycleDbPOSTAsync(newBicycle);
    public async Task CreateBicycleType(BicycleTypeDto newType) => await _client.BicycleTypeDbPOSTAsync(newType);
    public async Task CreateBicycleRenter(BicycleRenterDto newRenter) => await _client.BicycleRenterDbPOSTAsync(newRenter);
    public async Task CreateRent(RentDto newRent) => await _client.RentDbPOSTAsync(newRent);

    public async Task UpdateBicycle(int id, BicycleDto newBicycle) => await _client.BicycleDbPUTAsync(id, newBicycle);
    public async Task UpdateBicycleType(int id, BicycleTypeDto newType) => await _client.BicycleTypeDbPUTAsync(id, newType);
    public async Task UpdateBicycleRenter(int id, BicycleRenterDto newRenter) => await _client.BicycleRenterDbPUTAsync(id, newRenter);
    public async Task UpdateRent(int id, RentDto newRent) => await _client.RentDbPUTAsync(id,  newRent);


    public async Task DeleteBicycle(int id) => await _client.BicycleDbDELETEAsync(id);
    public async Task DeleteBicycleType(int id) => await _client.BicycleTypeDbDELETEAsync(id);
    public async Task DeleteBicycleRenter(int id) => await _client.BicycleRenterDbDELETEAsync(id);
    public async Task DeleteRent(int id) => await _client.RentDbDELETEAsync(id);

    public async Task<BicycleDto> GetBicycle(int id) => await _client.BicycleDbGETAsync(id);
    public async Task<BicycleTypeDto> GetBicycleType(int id) => await _client.BicycleTypeDbGETAsync(id);
    public async Task<BicycleRenterDto> GetBicycleRenter(int id) => await _client.BicycleRenterDbGETAsync(id);
    public async Task<RentDto> GetRent(int id) => await _client.RentDbGETAsync(id);


    public async Task<IEnumerable<BicycleDto>> GetAllBicycles() => await _client.BicycleDbAllAsync();
    public async Task<IEnumerable<BicycleTypeDto>> GetAllBicycleTypes() => await _client.BicycleTypeDbAllAsync();
    public async Task<IEnumerable<BicycleRenterDto>> GetAllBicycleRenters() => await _client.BicycleRenterDbAllAsync();
    public async Task<IEnumerable<RentDto>> GetAllRents() => await _client.RentDbAllAsync();


    public async Task<IEnumerable<BicycleDto>> InfoSportBike() => await _client.GetInfoSportBikeAsync();
    public async Task<IEnumerable<BicycleRenterDto>> InfoClientMountain() => await _client.GetInfoClientMountainAsync();
    public async Task<IEnumerable<DoubleBicycleTypeDtoNumberAndEntity>> SumTimeRentForType() => await _client.GetSumTimeRentForTypeAsync();
    public async Task<IEnumerable<Int32BicycleRenterDtoNumberAndEntity>> ClientsMaxRent() => await _client.GetClientsMaxRentAsync();
    public async Task<IEnumerable<Int32BicycleDtoNumberAndEntity>> TopRentBikes() => await _client.GetTopRentBikesAsync();
    public async Task<IEnumerable<double>> StatisticTimeRent() => await _client.GetStatisticTimeRentAsync();
}
